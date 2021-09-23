<template>
  <div>
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
            <select v-else v-model="produto.fornecedor">
              <option
                v-for="(fornecedor, index) in fornecedores"
                :key="index"
                v-bind:value="fornecedor"
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
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/produtos/" + this.id)
      .then((res) => res.json())
      .then((produto) => (this.produto = produto));

    this.$http
      .get("http://localhost:3000/fornecedores")
      .then((res) => res.json())
      .then((fornecedor) => (this.fornecedores = fornecedor));
  },
  methods: {
    editar() {
      this.visualizando = !this.visualizando;
    },

    salvar(_produto) {
      let _produtoEditar = {
        id: _produto.id,
        nome: _produto.nome,
        preco: _produto.preco,
        codBarra: _produto.codBarra,
        img: _produto.img,
        fornecedor: _produto.fornecedor,
      };
      this.$http.put(
        `http://localhost:3000/produtos/${_produtoEditar.id}`,
        _produtoEditar
      );
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
