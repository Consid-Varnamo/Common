﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Denna kod har genererats av ett verktyg.
//     Körtidsversion:4.0.30319.34209
//
//     Ändringar i denna fil kan orsaka fel och kommer att förloras om
//     koden återgenereras.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IAuthenticate")]
public interface IAuthenticate
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/ValidateKey", ReplyAction="http://tempuri.org/IAuthenticate/ValidateKeyResponse")]
    bool ValidateKey(System.Guid Ticket);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/ValidateKey", ReplyAction="http://tempuri.org/IAuthenticate/ValidateKeyResponse")]
    System.Threading.Tasks.Task<bool> ValidateKeyAsync(System.Guid Ticket);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/GetUserId", ReplyAction="http://tempuri.org/IAuthenticate/GetUserIdResponse")]
    string GetUserId(System.Guid Ticket);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/GetUserId", ReplyAction="http://tempuri.org/IAuthenticate/GetUserIdResponse")]
    System.Threading.Tasks.Task<string> GetUserIdAsync(System.Guid Ticket);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/GetUserRoles", ReplyAction="http://tempuri.org/IAuthenticate/GetUserRolesResponse")]
    string[] GetUserRoles(System.Guid Ticket);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticate/GetUserRoles", ReplyAction="http://tempuri.org/IAuthenticate/GetUserRolesResponse")]
    System.Threading.Tasks.Task<string[]> GetUserRolesAsync(System.Guid Ticket);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IAuthenticateChannel : IAuthenticate, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class AuthenticateClient : System.ServiceModel.ClientBase<IAuthenticate>, IAuthenticate
{
    
    public AuthenticateClient()
    {
    }
    
    public AuthenticateClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public AuthenticateClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AuthenticateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AuthenticateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public bool ValidateKey(System.Guid Ticket)
    {
        return base.Channel.ValidateKey(Ticket);
    }
    
    public System.Threading.Tasks.Task<bool> ValidateKeyAsync(System.Guid Ticket)
    {
        return base.Channel.ValidateKeyAsync(Ticket);
    }
    
    public string GetUserId(System.Guid Ticket)
    {
        return base.Channel.GetUserId(Ticket);
    }
    
    public System.Threading.Tasks.Task<string> GetUserIdAsync(System.Guid Ticket)
    {
        return base.Channel.GetUserIdAsync(Ticket);
    }
    
    public string[] GetUserRoles(System.Guid Ticket)
    {
        return base.Channel.GetUserRoles(Ticket);
    }
    
    public System.Threading.Tasks.Task<string[]> GetUserRolesAsync(System.Guid Ticket)
    {
        return base.Channel.GetUserRolesAsync(Ticket);
    }
}
