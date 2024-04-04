using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
