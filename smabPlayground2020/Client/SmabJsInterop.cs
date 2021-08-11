using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace smabPlayground2020.Client;

// The associated JavaScript module is loaded on demand when first needed.
//
// This class should be registered as scoped DI service and then injected into Blazor
// components for use.

public class SmabJsInterop : IAsyncDisposable {
	private readonly Lazy<Task<IJSObjectReference>> moduleTask;

	public SmabJsInterop(IJSRuntime jsRuntime) {
		moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "/smabJsInterop.js").AsTask());
			//"import", "./_content/smabPlayground2020.Client/smabJsInterop.js").AsTask());
	}

	public async ValueTask<string> CopyToClipboard(ElementReference reference) {
		var module = await moduleTask.Value;
		return await module.InvokeAsync<string>("copyText", reference);
	}

	public async void CreateCookie(string name, string value, int? days = null) {
		var module = await moduleTask.Value;
		await module.InvokeAsync<string>("createCookie", name, value, days);
	}

	public async void DeleteCookie(string name) {
		var module = await moduleTask.Value;
		await module.InvokeAsync<string>("deleteCookie", name);
	}

	public async ValueTask<string> ReadCookie(string name) {
		var module = await moduleTask.Value;
		return await module.InvokeAsync<string>("readCookie", name);
	}

	public async ValueTask<string> ShowPrompt(string message) {
		var module = await moduleTask.Value;
		return await module.InvokeAsync<string>("showPrompt", message);
	}


	public async ValueTask DisposeAsync() {
		if (moduleTask.IsValueCreated) {
			var module = await moduleTask.Value;
			await module.DisposeAsync();
		}
	}
}
