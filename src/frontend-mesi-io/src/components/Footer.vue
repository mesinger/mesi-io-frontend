<template>
  <div>
    <footer class="bg-primary">
      <div class="pt-3"></div>
      <div class="text-center">
        © 2020
        <a href="https://github.com/mesinger" target="_blank">Github</a>
      </div>
    </footer>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component
export default class Footer extends Vue {}
</script>
