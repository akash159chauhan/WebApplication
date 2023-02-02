namespace WebApplication1
{
	public class ServiceResponse<T>
	{
		public T? Data { get; set; }
		public string? InitialTime { get; set; }
		public string? CompletionTime { get; set; }
		public string? Query { get; set; }
	}
}
