using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services
{
    public interface IListResultService
    {
        ListResultModel ListResults(int page, List<ListModel> listModel);
    }
}
