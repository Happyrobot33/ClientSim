"use strict";(self.webpackChunkclient_sim=self.webpackChunkclient_sim||[]).push([[5625],{3905:(e,t,n)=>{n.d(t,{Zo:()=>d,kt:()=>m});var r=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function s(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?s(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):s(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function a(e,t){if(null==e)return{};var n,r,i=function(e,t){if(null==e)return{};var n,r,i={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var c=r.createContext({}),l=function(e){var t=r.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},d=function(e){var t=l(e.components);return r.createElement(c.Provider,{value:t},e.children)},p="mdxType",u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},h=r.forwardRef((function(e,t){var n=e.components,i=e.mdxType,s=e.originalType,c=e.parentName,d=a(e,["components","mdxType","originalType","parentName"]),p=l(n),h=i,m=p["".concat(c,".").concat(h)]||p[h]||u[h]||s;return n?r.createElement(m,o(o({ref:t},d),{},{components:n})):r.createElement(m,o({ref:t},d))}));function m(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var s=n.length,o=new Array(s);o[0]=h;var a={};for(var c in t)hasOwnProperty.call(t,c)&&(a[c]=t[c]);a.originalType=e,a[p]="string"==typeof e?e:i,o[1]=a;for(var l=2;l<s;l++)o[l]=n[l];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}h.displayName="MDXCreateElement"},5998:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>o,default:()=>u,frontMatter:()=>s,metadata:()=>a,toc:()=>l});var r=n(7462),i=(n(7294),n(3905));const s={id:"architecture",title:"Architecture",hide_title:!0},o="Architecture",a={unversionedId:"systems/architecture",id:"systems/architecture",title:"Architecture",description:"The architecture of ClientSim has a focus on small components with an event based observer pattern, mixed with manual dependency injection where each class is initialized only with the dependencies it needs. The included player controller is based on generic dependency providers, which allows for the eventual extension to using VR without rewriting the core systems.",source:"@site/docs/systems/architecture.md",sourceDirName:"systems",slug:"/systems/architecture",permalink:"/systems/architecture",draft:!1,editUrl:"https://github.com/vrchat-community/ClientSim/edit/main/Docs/Source/systems/architecture.md",tags:[],version:"current",frontMatter:{id:"architecture",title:"Architecture",hide_title:!0},sidebar:"tutorialSidebar",previous:{title:"Systems",permalink:"/systems/"},next:{title:"Automated Testing",permalink:"/systems/automated-testing"}},c={},l=[{value:"Observer Pattern",id:"observer-pattern",level:2},{value:"Dependency Injection",id:"dependency-injection",level:2}],d={toc:l},p="wrapper";function u(e){let{components:t,...n}=e;return(0,i.kt)(p,(0,r.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"architecture"},"Architecture"),(0,i.kt)("p",null,"The architecture of ClientSim has a focus on small components with an event based observer pattern, mixed with manual dependency injection where each class is initialized only with the dependencies it needs. The included player controller is based on generic dependency providers, which allows for the eventual extension to using VR without rewriting the core systems."),(0,i.kt)("h2",{id:"observer-pattern"},"Observer Pattern"),(0,i.kt)("p",null,"ClientSim uses the observer pattern to send events within the system that anything can listen to without knowing what handles them. Events help decouple the different systems, improving testability as one system does not need to directly depend on another just to send messages when something happens. See ",(0,i.kt)("a",{parentName:"p",href:"/systems/runtime/event-dispatcher"},"EventDispatcher")," for specific details."),(0,i.kt)("h2",{id:"dependency-injection"},"Dependency Injection"),(0,i.kt)("p",null,"ClientSim\u2019s architecture uses a manually-handled dependency injection. On creation of a system, all dependencies are passed to it, either through its constructor or through an initialization method. Dependencies are structured as providers, and must extend an interface that declares what methods it provides. When a class needs a specific item, it depends on the provider interface instead of the class that implements it. This allows for different implementations of the provider without the dependent code needing to change. The provider pattern allows for dependencies to easily be mocked in tests."))}u.isMDXComponent=!0}}]);