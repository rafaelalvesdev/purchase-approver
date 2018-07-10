// import {
//     Directive,
//     ViewContainerRef,
//     OnInit,
//     Input,
//     ComponentFactoryResolver,
//     Type,
//     ViewChild
// } from '@angular/core';

// @Directive({
//     selector: '[appComponentHost]'
// })
// export class ComponentHostDirective implements OnInit {

//     @Input() componentType: Type<any>;

//     @ViewChild(ComponentHostDirective) host: ComponentHostDirective;

//     constructor(public viewContainerRef: ViewContainerRef,
//         private componentFactoryResolver: ComponentFactoryResolver) { }

//     ngOnInit(): void {
//         this.loadComponent();
//     }

//     loadComponent(): void {
//         const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.componentType);
//         this.viewContainerRef.clear();
//         this.viewContainerRef.createComponent(componentFactory);
//     }
// }
