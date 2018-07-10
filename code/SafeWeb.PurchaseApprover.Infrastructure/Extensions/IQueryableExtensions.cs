using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Remotion.Linq.Parsing.Structure;
using SafeWeb.PurchaseApprover.Infrastructure.Strategies;
using System;
using System.Linq;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SafeWeb.PurchaseApprover.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Configure<T, TFetch>(this IQueryable<T> q)
            where TFetch : IFetchStrategy<T>
        {
            var strategy = (TFetch)Activator.CreateInstance(typeof(TFetch));
            return strategy.Configure(q);
        }



        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();
            FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
            PropertyInfo NodeTypeProviderField = QueryCompilerTypeInfo.DeclaredProperties.Single(x => x.Name == "NodeTypeProvider");
            MethodInfo CreateQueryParserMethod = QueryCompilerTypeInfo.DeclaredMethods.First(x => x.Name == "CreateQueryParser");
            FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
            FieldInfo QueryCompilationContextFactoryField = typeof(Database).GetTypeInfo().DeclaredFields.Single(x => x.Name == "_queryCompilationContextFactory");

            if (!(query is EntityQueryable<TEntity>) && !(query is InternalDbSet<TEntity>))
                throw new ArgumentException("Invalid query");

            var queryCompiler = (IQueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var nodeTypeProvider = (INodeTypeProvider)NodeTypeProviderField.GetValue(queryCompiler);
            var parser = (IQueryParser)CreateQueryParserMethod.Invoke(queryCompiler, new object[] { nodeTypeProvider });
            var queryModel = parser.GetParsedQuery(query.Expression);
            var database = DataBaseField.GetValue(queryCompiler);
            var queryCompilationContextFactory = (IQueryCompilationContextFactory)QueryCompilationContextFactoryField.GetValue(database);
            var queryCompilationContext = queryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}