using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Descripción breve de IServicePresidente
/// </summary>
[ServiceContract]
public interface IServicePresidentes
{
    [OperationContract]
    List<Presidentes> GetPresidente();
}