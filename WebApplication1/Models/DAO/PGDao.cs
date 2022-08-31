using Npgsql;

namespace WebApplication1.Models.DAO
{
	public class PGDao
	{
		public object? GetValue()
		{
			var connString = "Host=localhost;Username=postgres;Password=;Database=test";

			using var conn = new NpgsqlConnection(connString);
			conn.Open();

			// Insert some data
			//using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES (@p)", conn))
			//{
			//	cmd.Parameters.AddWithValue("p", "Hello world");
			//	cmd.ExecuteNonQueryAsync();
			//}

			// Retrieve all rows
			using (var cmd = new NpgsqlCommand("SELECT \"Id\", text	FROM public.course", conn))
			using (var reader = cmd.ExecuteReader())
			{
				if (reader.Read())
				{
					return reader.GetValue(0);
				}
			}
			return null;
		}
	}
}
