using Microsoft.Extensions.Caching.Memory;

namespace PlanificadorAPI
{
    public class ServiceTask : IServiceTask, IHostedService, IDisposable
    {
        private readonly IMemoryCache _memoryCache;
        private Timer _timer;
        public ServiceTask(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

        }

        //Inicia la tarea cada 10 segundos de manera infinita
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(EjecutarTarea, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
        
        //Tarea que se ejecutara
        public void EjecutarTarea(object state)
        {
            List<string> datos = null;
            if(!_memoryCache.TryGetValue("data", out datos))
            {
                datos = new List<string>();
            }
            Random random = new Random();
            datos.Add($"nombre{random.Next(1000)}");
            _memoryCache.Set("data", datos);
        }

        //Metodo para obtener los datos
        public List<string> GetData()
        {
            List<string> data = new List<string>();
            _memoryCache.TryGetValue("data", out data);

            return data;
        }

    }
}
