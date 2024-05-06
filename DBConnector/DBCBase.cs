using System;

namespace DBConnector
{
	/// <summary>
	/// 
	/// </summary>
	public class DBCBase : IDisposable
	{
		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value>
		/// The connection string.
		/// </value>
		public string ConnectionString { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this instance has error.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
		/// </value>
		public bool HasError { get; set; }
		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>
		/// The error message.
		/// </value>
		public string ErrorMessage { get; set; }

		private bool disposed = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="DBCBase"/> class.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		public DBCBase(string connectionString)
		{
			ConnectionString = connectionString;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DBCBase"/> class.
		/// </summary>
		public DBCBase()
		{
			
		}

		/// <summary>
		/// Sets the error.
		/// </summary>
		/// <param name="errorMessage">The error message.</param>
		public void SetError(string errorMessage)
		{
			HasError = true;
			ErrorMessage = errorMessage;
		}

		/// <summary>
		/// Clears the error.
		/// </summary>
		public void ClearError()
		{
			HasError = false;
			ErrorMessage = string.Empty;
		}

		/// <summary>
		/// Release resources.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					ConnectionString = null;
					ErrorMessage = null;
				}

				disposed = true;
			}
		}

		/// <summary>
		/// Release resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}

	/// <summary>
	///   <br />
	/// </summary>
	public class ParameterList
	{
		/// <summary>
		/// Gets or sets the Parameter Key.
		/// </summary>
		/// <value>
		/// The Parameter Key.
		/// </value>
		public string Key { get; set; }
		/// <summary>
		/// Gets or sets the Parameter Value.
		/// </summary>
		/// <value>
		/// The Parameter Value.
		/// </value>
		public string Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterList"/> class.
		/// </summary>
		/// <param name="ParameterKey">The Parameter Key.</param>
		/// <param name="ParameterValue">The Parameter Value.</param>
		public ParameterList(string ParameterKey, string ParameterValue)
		{
			Key = ParameterKey;
			Value = ParameterValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterList"/> class.
		/// </summary>
		public ParameterList()
		{
		}
	}

}
