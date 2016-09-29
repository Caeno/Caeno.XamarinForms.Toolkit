using System;
using System.Threading.Tasks;

namespace Caeno.XamarinForms.Toolkit
{
	public class AsyncViewModelBase : ViewModelBase
	{

		#region Properties

		bool _isLoaded = false;
		/// <summary>
		/// A flag indicating if this componente is loaded.
		/// </summary>
		/// <value>The is data available.</value>
		public bool IsLoaded {
			get { return _isLoaded; }
			protected set { SetProperty(ref _isLoaded, value); }
		}


		bool _isRunningOperation;
		/// <summary>
		/// Gets a value indicating if this object is Running some operation.
		/// </summary>
		/// <value>The is running operation.</value>
		public bool IsRunningOperation {
			get { return _isRunningOperation; }
			protected set { SetProperty(ref _isRunningOperation, value); }
		}

		string _operationMessage;
		/// <summary>
		/// Gets a value indicating the message of the operation that is running.
		/// </summary>
		/// <value>The operation message.</value>
		public string OperationMessage {
			get { return _operationMessage; }
			set { SetProperty(ref _operationMessage, value); }
		}

		#endregion


		#region Methods

		public async void RunOnBackground(Func<Task> action, string operationMessage = null) {
			if (operationMessage != null)
				OperationMessage = operationMessage;

			IsRunningOperation = true;
			await action();
			IsRunningOperation = false;
		}


		#endregion

	}
}

