<template>
  <div class="barraTop">
    <nav class="marginPrincipal">
      <router-link to="/fornecedores">Fornecedores</router-link>
      <router-link to="/produtosall">Produtos</router-link>
      <router-link to="/sobre">Sobre XPTO</router-link>
    </nav>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.barraTop {
  background-color: rgb(230, 230, 230);
}

nav {
  padding: 20px 20px 20px 20px;
}
nav a {
  padding: 10px;
  text-decoration: none;
  background-color: "#fff";
  border-radius: 5px;
  color: rgb(0, 110, 225);
  font-weight: bold;
  margin-right: 15px;
}
nav .router-link-active {
    background-color: rgb(160, 160,160);
    color: white
}
</style>
