<template>
  <div>
    <Titulo texto="fornecedores XPTO" />
    <table>
      <thead>
        <th>Cod.</th>
        <th>Nome Fornecedor</th>
        <th>Ações</th>
      </thead>
      <tbody v-if="fornecedores.length">
        <tr v-for="(fornecedor, index) in fornecedores" :key="index">
          <td>{{ fornecedor.id }}</td>
          <td>{{ fornecedor.nome }}</td>
          <td>
            <button
              title="Excluir Fornecedor"
              class="btn_Danger"
              @click="remover(fornecedor)"
            >
              <img
                class="imgIcone"
                style="cursor: pointer"
                src="https://img.icons8.com/nolan/50/delete.png"
              />
            </button>
            <router-link v-bind:to="`/produtos/${fornecedor.id}`">
              <img
                title="Visualizar Produtos"
                class="imgIcone"
                style="cursor: pointer"
                src="https://img.icons8.com/nolan/50/info.png"
              />
            </router-link>
          </td>
        </tr>
      </tbody>
      <t-foot v-else>Nenhum produto encontrado</t-foot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo.vue";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      fornecedores: [],
      Produtos: [],
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/produtos")
      .then((res) => res.json())
      .then((produtos) => {
        this.Produtos = produtos;
        this.carregarfornecedores();
      });
  },
  props: {},
  methods: {
    pegarQtdProdutosPorFornecedor() {
      this.fornecedores.forEach((fornecedor, index) => {
        fornecedor = {
          id: fornecedor.id,
          nome: fornecedor.nome,
          qtdProdutos: this.Produtos.filter(
            (produto) => produto.fornecedor.id == fornecedor.id
          ).length,
        };
        this.fornecedores[index] = fornecedor;
      });
    },
    carregarfornecedores() {
      this.$http
        .get("http://localhost:3000/fornecedores")
        .then((res) => res.json())
        .then((fornecedor) => {
          this.fornecedores = fornecedor;
          this.pegarQtdProdutosPorFornecedor();
        });
    },
  },
};
</script>

<style scoped></style>
