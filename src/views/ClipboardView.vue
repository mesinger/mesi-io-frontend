<template>
  <div>
    <div class="container-fluid pt-2 pb-2">
      <div class="rounded dashboard-item">
        <h1 class="display-4">Clipboard</h1>
        <input
          v-model="newEntry"
          type="text"
          class="form-control"
          placeholder="Add a new clipboard entry ..."
        />
        <button @click="addNewEntry" class="btn mt-2 w-100 button-primary">
          Add
        </button>
      </div>
    </div>

    <div class="container-fluid pt-2 pb-2">
      <div class="rounded dashboard-item">
        <h3>Previous entries</h3>

        <table class="table table-striped">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Content</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(entry, index) in entries" :key="index">
              <th scope="row">{{ index + 1 }}</th>
              <td>
                <strong>{{
                  entry.content.length > 20
                    ? entry.content.substring(0, 20) + "..."
                    : entry.content
                }}</strong>
              </td>
              <td>
                <a @click="doCopy(entry.content)" class="copy-link">Copy</a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import axios from "axios";
import VueClipboard from "vue-clipboard2";
import { ClipboardEntry } from "@/entities/clipboard/ClipboardEntry";
import { namespace, Getter } from "vuex-class";

Vue.use(VueClipboard);

@Component
export default class ClipboardView extends Vue {
  entries: ClipboardEntry[] = [];
  newEntry = "";
  @(namespace("profile").Getter("isLoggedIn")) isLoggedIn!: boolean;
  @(namespace("profile").Getter("userId")) userId!: string;
  @(namespace("profile").Getter("authToken")) token!: string;

  mounted() {
    if (!this.isLoggedIn) {
      this.$router.push("/");
    } else {
      axios
        .request({
          url: `https://api.mesi.io/clipboard/${this.userId}`,
          method: "get",
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        .then(rsp => (this.entries = rsp.data));
    }
  }

  doCopy(content: string) {
    this.$copyText(content);
  }

  addNewEntry() {
    axios
      .request({
        url: "https://api.mesi.io/clipboard/",
        method: "post",
        data: {
          userid: this.userId,
          content: this.newEntry
        },
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      })
      .then(response => {
        this.entries.push({ content: this.newEntry, timeStamp: "" });
        this.newEntry = "";
      });
  }
}
</script>

<style lang="scss" scoped>
.copy-link {
  &:hover {
    cursor: pointer;
    text-decoration: underline;
  }
}
</style>
