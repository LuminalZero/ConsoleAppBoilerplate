namespace ConsoleAppBoilerplate.ConsoleApp.Services.Interfaces
{
    internal interface IExampleService
    {
        Task<string> DoWork(CancellationToken cancellationToken);
    }
}
