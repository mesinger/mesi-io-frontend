<template>
  <div>
    <div class="container-fluid pt-2 pb-2">
      <div class="rounded dashboard-item">
        <p class="display-4">Clipboard</p>
        <p>Add new clipboard entries to an online clipboard.</p>
        <a href="/clipboard" class="btn bg-primary text-white float-right mr-3 mb-2"
          >Go</a
        >
        <div class="clearfix"></div>
      </div>
    </div>

    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-6 pt-2 pb-2">
          <div class="rounded dashboard-item h-100">
            <h3>mesi.io</h3>
            <p>
              This is my personal development project. You propably won't find
              anything usefull here.
              <br />However, everything you see here was made by me, from
              writing the web application in kotlin with spring boot, designing
              the frontend, or deploying my application on AWS with docker
              containers.
            </p>
          </div>
        </div>
        <div class="col-sm-6 pt-2 pb-2">
          <div class="rounded dashboard-item h-100">
            <h3>Current technology stack</h3>
            <div class="image-techstack-container">
              <img
                src="~@/assets/img/kotlin-50.png"
                alt="image"
                class="img-thumbnail align-bottom"
                height="50px"
              />
              <img
                src="~@/assets/img/springboot-50.jpg"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/vue-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/gradle-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/mongodb-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/docker-logo-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/aws-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
              <img
                src="~@/assets/img/nginx-50.png"
                alt="image"
                class="img-thumbnail"
                height="50px"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component
export default class Home extends Vue {}
</script>

<style lang="scss" scoped>
.image-techstack-container {
  img {
    margin-right: 8px;
    margin-bottom: 5px;
  }
}
</style>
