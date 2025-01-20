import type { DotNet } from "@microsoft/dotnet-js-interop";

export class DotNetHelpers {
	static dotNetHelper: DotNet.DotNetObject

	static setDotNetObjectReference(value: DotNet.DotNetObject) {
		DotNetHelpers.dotNetHelper = value;
	}

	static async showToastSuccess(message: string) {
		const res = await DotNetHelpers.dotNetHelper.invokeMethodAsync('ToastSuccess', message);
	}
}

export function addCodeSelection(triggerId: string, codeId: string) {
  const el = document.getElementById(triggerId);
  el.addEventListener("click", () => selectChildren(codeId));
}
export function selectChildren(codeId: string) {
  const codeEl = document.getElementById(codeId);
	if (codeEl) {
		window.getSelection().selectAllChildren(codeEl);
		document.execCommand("copy");
		window.getSelection().removeAllRanges();

		// TODO:later
		//try {
			// await navigator.clipboard.writeText(text);
		//} catch (error) {
			// console.error(error.message);
		//}
		DotNetHelpers.showToastSuccess("Copied");
  }
}
