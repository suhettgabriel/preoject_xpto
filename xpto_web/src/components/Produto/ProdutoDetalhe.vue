<template>
  <div v-if="!loading">
    <Titulo :texto="`Produto: ${produto.nome}`" :btnVoltar="true"> /> </Titulo>
    <img
      src="https://img.icons8.com/nolan/64/edit--v1.png"
      class="btnEditar"
      title="Editar Produto"
      style="cursor: pointer"
      @click="editar()"
    />
    <img
      v-if="!visualizando"
      src="https://img.icons8.com/nolan/64/cancel.png"
      class="btnEditar"
      title="Cancelar Edição"
      style="cursor: pointer"
      @click="cancelar()"
    />
    <img
      v-if="!visualizando"
      src="https://img.icons8.com/nolan/64/save-close.png"
      class="btnEditar"
      title="Salvar Produto"
      style="cursor: pointer"
      @click="salvar(produto)"
    />
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Cod. Produto</td>
          <td class="lblProduto">
            <label>{{ produto.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Descrição:</td>
          <td class="lblProduto">
            <label v-if="visualizando">{{ produto.nome }}</label>
            <input v-else v-model="produto.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Preço:</td>
          <td class="lblProduto">
            <label v-if="visualizando">{{ produto.preco }}</label>
            <input v-else v-model="produto.preco" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Cod. Barra:</td>
          <td class="lblProduto">
            <label v-if="visualizando">{{ produto.codBarra }}</label>
            <input v-else v-model="produto.codBarra" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Imagem:</td>
          <td class="lblProduto">
            <label v-if="visualizando">{{ produto.img }}</label>
            <input v-else v-model="produto.img" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Fornecedor:</td>
          <td class="lblProduto">
            <label v-if="visualizando">{{ produto.fornecedor.nome }}</label>
            <select v-else v-model="produto.fornecedor.id">
              <option
                v-for="(fornecedor, index) in fornecedores"
                :key="index"
                v-bind:value="fornecedor.id"
              >
                {{ fornecedor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      fornecedores: [],
      produto: {},
      visualizando: true,
      id: this.$route.params.id,
      loading: true,
    };
  },
  created() {
    this.carregaFornecedor();
  },
  methods: {
    carregarFornecedor() {
      this.$http
        .get("http://localhost:5000/api/fornecedor")
        .then((res) => res.json())
        .then(fornecedor => {
          this.fornecedores = fornecedor;
          this.carregarProduto();
          
          });
    },
    carregarProduto() {
      this.$http
        .get("http://localhost:5000/api/produto/" + this.id)
        .then((res) => res.json())
        .then(produto => {
          this.produto = produto;
          this.loading=false;
          });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },

    salvar(produto) {
      let _produtoEditar = {
        id: produto.id,
        nome: produto.nome,
        preco: produto.preco,
        codBarra: produto.codBarra,
        img: produto.img,
        fornecedorid: produto.fornecedor.id
      }
      this.$http
        .put(`http://localhost:5000/api/produto/${_produtoEditar.id}`,_produtoEditar)
        .then(res => res.json())
        .then(produto = this.produto = produto)

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    },
  },
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
  text-align: right;
  background-color: rgb(230, 230, 230);
  color: #4682b4;
  font-weight: 400;
}
input,
select {
  margin: 0px;
  padding: 5px 10px;
  border-radius: 5px;
  border: 1px solid silver;
  font-size: 0.8em;
  font-family: Montserrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}

select {
  height: 28px;
  width: 98%;
}
.btnEditar {
  float: right;
  width: 4%;
  padding-left: 40px;
}
.lblProduto {
  background-color: white;
  color: #4682b4;
  border: 3px;
  border-radius: 10px;
}
</style>
