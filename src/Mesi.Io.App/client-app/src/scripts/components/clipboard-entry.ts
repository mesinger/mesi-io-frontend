import { customElement, html, internalProperty, LitElement, property } from "lit-element";

@customElement("clipboard-entry")
export class ClibpardEntryComponent extends LitElement {
  constructor() {
    super();
  }

  createRenderRoot(): LitElement {
    return this;
  }

  @property()
  index!: number;

  @property()
  content!: string;

  inputFieldId(): string {
    return `copyTextInput-${this.index}`;
  }

  public render() {
    return html`<div class="d-block">
      <div class="d-inline-block w-25">${this.index}</div>
      <div class="d-inline-block w-50">${this.content}</div>
      <div class="d-inline-block w-auto">
        <button class="btn btn-primary" @click="${this.copyToClipboard}">Copy</a>
      </div>
    </div>
    <input style="position: absolute;top: 0;left: 0;z-index: -1" id="${this.inputFieldId()}" type=text .value="${this.content}"></input>`;
  }

  copyToClipboard() {
    const copyTextInputField = <HTMLInputElement>document.getElementById(this.inputFieldId());
    copyTextInputField.select();
    copyTextInputField.setSelectionRange(0, 99999);
    document.execCommand("copy");
  }
}

declare global {
  interface HTMLElementTagNameMap {
    "clipboard-entry": ClibpardEntryComponent;
  }
}
