import Vue from "vue";
import Router from "vue-router";
import Produtos from "./components/Produto/Produtos.vue";
import ProdutoDetalhe from "./components/Produto/ProdutoDetalhe.vue"
import Fornecedor from "./components/Fornecedor/Fornecedor.vue";
import Sobre from "./components/Sobre/Sobre.vue";

Vue.use(Router);
export default new Router({
  routes: [
    {
      path: "/fornecedores",
      nome: "Fornecedores",
      component: Fornecedor,
    },
    {
      path: "/produtos/:forn_id",
      nome: "Produtos",
      component: Produtos,
    },
    {
      path: "/produtosall",
      nome: "Produtos",
      component: Produtos,
    },
    {
      path: '/produtoDetalhe/:id',
      nome: 'ProdutoDetalhe',
      component: ProdutoDetalhe,
    },
    {
      path: "/sobre",
      nome: "Sobre",
      component: Sobre,
    },
  ],
});
