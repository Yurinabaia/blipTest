using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
namespace WebApiHeroku.Core.Entites
{
    [Headers("User-Agent: Usando Agente GITHUB")]

    public interface Igit
    {
        [Get("/users/{user}/repos")]
        Task<List<Root>> GetUser(string user);

    }
}