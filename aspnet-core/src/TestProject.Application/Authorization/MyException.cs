using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Abp.Logging;
using Abp.Runtime.Session;
using TestProject.Authorization.Users;

namespace TestProject.Authorization
{
    public class MyException : IEventHandler<AbpHandledExceptionData>, ITransientDependency
    {
        //AbpHandledExceptionData
        //public void HandleEvent(AbpAuthorizationException eventData)
        //{
        //    var e = eventData.Message;
        //}
        private readonly IAbpSession _session;

        public MyException(IAbpSession session)
        {
            _session = session;
        }

        

        public void HandleEvent(AbpHandledExceptionData eventData)
        {
            var e = eventData.Exception;
            var user = _session.UserId;
            //using (_session.Use(1, 2))
            //{
            //    //var tenantId = _session.TenantId; //42
            //    var userId = _session.UserId; //null
            //}

        }
    }
}
