import {
  customElement,
  html,
  internalProperty,
  LitElement
} from "lit-element";

@customElement("clipboard-app")
export class ClibpardAppComponent extends LitElement {
  constructor() {
    super();
  }

  createRenderRoot(): LitElement {
    return this;
  }

  public render() {
    return html`<input type="text" .value="${this.newContent}" @change="${this.updateNewContent}"/><button @click="${this._handleClick}" .disabled="${this.disabled}">Copy</button><input style="position: absolute;top: 0;left: 0;z-index: -1" id="copyTextInput" type=text .value="${this.newContent}"></input>`;
  }

  @internalProperty()
  newContent: string = "";

  updateNewContent(e: any) {
    this.newContent = e.srcElement.value;
  }

  disabled(): boolean {
    return this.newContent !== "";
  }

  _handleClick() {
    const copyText = <HTMLInputElement>document.getElementById("copyTextInput");
    copyText.select();
    copyText.setSelectionRange(0, 99999);
    document.execCommand("copy");
  }
}

declare global {
  interface HTMLElementTagNameMap {
    "clipboard-app": ClibpardAppComponent;
  }
}
