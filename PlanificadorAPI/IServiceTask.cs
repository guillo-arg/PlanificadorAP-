
namespace PlanificadorAPI
{
    public interface IServiceTask
    {
        void EjecutarTarea(object data);
        List<string> GetData();
    }
}
