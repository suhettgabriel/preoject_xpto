<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Nav from "./components/_nav/Nav.vue";

export default {
  name: "App",
  components: {
    Nav,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body,
html {
  margin: 0;
  height: 100%;
}
.marginPrincipal {
  width: 80%;
  margin: auto;
}
#app {
  width: 100%;
}
.btn_Danger {
  background-color: #e0edf4;
  border: 0px;
  padding: 10px 20px;
}
.btn {
  padding: 10px 20px;
  cursor: pointer;
  border: 1px solid #000;
  color: #fff;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
}
.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}
table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
  border: 0px;
  padding-top: 10px;
}
table tr td {
  padding: 5px;
  font-size: 1em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #4682b4;
}
table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1em;
  font-weight: 500;
  padding: 10px 0px;
  text-align: center !important;
  padding: 5px 5px 5px 5px;
  color:#4682b4
}
.colPequeno {
  width: 5%;
}
.cadastroProduto {
  border: 1px solid rgb(184, 208, 216) !important;
  border-radius: 5px !important;
  padding: 0px 15px 20px 15px !important;
}
.imgIcone {
  width: 25px;
  display: inline;
}
.tituloCadastroProduto {
  color: #4682b4;
}
</style>
