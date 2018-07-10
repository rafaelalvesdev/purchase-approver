using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Web.Controllers
{
    public class ProposalsController : BaseController
    {
        [HttpPost]
        public ServiceResult SaveProposal([FromServices] IProposalService proposalService, SaveProposalRequest request)
        {
            var message = Mapper.Map<SaveProposalMessage>(request);
            return proposalService.Save(message);
        }


        [Route("{id}")]
        [HttpGet]
        public ServiceResult GetProposal([FromServices] IProposalService proposalService, int id)
        {
            var result = proposalService.Get(id);
            return Mapper.Map<ServiceResult<ProposalViewModel>>(result);
        }


        [Route("{id}")]
        [HttpDelete]
        public ServiceResult DeleteProposal([FromServices] IProposalService proposalService, int id)
        {
            var result = proposalService.Delete(id);
            return result;
        }


        [Route("{id}/file")]
        [HttpPut]
        public ServiceResult SaveProposalFile([FromServices] IProposalService proposalService, [FromRoute] int id, [FromBody] ICollection<IFormFile> files)
        {
            var file = files.FirstOrDefault();
            var totalSize = file.Length;
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create)) file.CopyTo(stream); 

            var result = proposalService.SaveProposalFile(new SaveProposalFileMessage() {
                ProposalID = id,
                FilePath = filePath,
            });

            return result;
        }

        [HttpGet]
        public ServiceResult ListProposals([FromServices] IProposalRepository proposalRepository)
        {
            var result = proposalRepository.Get();
            return Mapper.Map<List<ProposalViewModel>>(result).AsServiceResultWithEntity().SetValid();
        }
    }
}