********************************************************************************************
                                    README FILE

1. This is a MakeMeLaughAPI written in DotnetCore 6.0.
2. This is using IISExpress or Kestrel for Hosting on Dev environment.
3. We have used SWAGGER to demonstrate the front-end.
4. This Solution has 2 components - MakeMeLaughAPI (Rest Service) and MakeMeLaughCore(DLL)



a. Why MakeMeLaughCore is a DLL?
    Answer: This is the core logic for this API to execute. API is just dumb service to process the request.
    At any time, we can update the logics in MakeMeLaughCore dll and inject the new DLL to the existing Hosted API, without unmounting the service.
    This would lead to zero downtime while upgrade. We only would need to unmount the service if new endpoints are being added.


b. We have given the url of https://icanhazdadjoke.com/api as an environment variable (in appsettings.json). In future if the endpoint url changes,
   we just need to update the new url at runtime, without ever pulling down the services.


c. In this we have used Dependency Injection, Abstraction, Inhertiance, Runtime Polymorphism. We have also given thoughts upon access modifiers.
   Please search for #degreed in the solution to look for comments and explanations, about various implementations.

********************************************************************************************