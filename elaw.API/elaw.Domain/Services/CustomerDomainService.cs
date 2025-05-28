using educaAcao.Domain.Notifications;
using educaAcao.Domain.Services;
using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Infra;
using elaw.Domain.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Domain.Services
{
    public class CustomerDomainService : BaseDomainService<Customer>, ICustomerDomainService
    {
        public CustomerDomainService(
            IBaseRepository<Customer> customerRepository,
            NotificationContext notificationContext,
            IValidator<Customer> customerValidator)
            : base(customerRepository, notificationContext, customerValidator)
        {
        }
    }
}
