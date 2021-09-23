<template>
  <div>
    <Titulo
      v-bind:texto="
        fornecedorId != undefined
          ? 'Fornecedor: ' + fornecedor.nome
          : 'Todos os Produtos'
      "
    />
    <div v-if="fornecedorId != undefined" class="cadastroProduto">
      <div class="tituloCadastroProduto">
        <h2>Cadastro de Produtos</h2>
      </div>
      <div class="inputs">
        <div class="inputNome">
          <label>Produto</label>
          <input type="text" v-model="nome" />
        </div>
        <div class="inputPreco">
          <label>Preço R$</label>
          <input type="number" v-model="preco" />
        </div>
        <div class="inputCodBarra">
          <label>Código de Barra</label>
          <input type="text" v-model="codBarra" />
        </div>
      </div>
      <label>Selecione uma imagem para o produto</label>
      <div class="inputImagem">
        <input style="width: 82%" type="file" />
        <Button
          style="width: 12% cursor: pointer"
          class="btn btnInput"
          @click="addProduto()"
          title="Adicionar Produto"
          >Adicionar</Button
        >
      </div>
    </div>

    <table>
      <thead>
        <th>Cod.</th>
        <th>Nome Produto</th>
        <th>Preço</th>
        <th>Cod. Barra</th>
        <th>Imagem</th>
        <th>Ações</th>
      </thead>
      <tbody v-if="produtos.length">
        <tr v-for="(produto, index) in produtos" :key="index">
          <td>{{ produto.id }}</td>
          <td>{{ produto.nome }}</td>
          <td>{{ produto.preco }}</td>
          <td>{{ produto.codBarra }}</td>
          <td>{{ produto.img }}</td>
          <td>
            <button class="btn_Danger" @click="remover(produto)">
              <img
                class="imgIcone"
                title="Excluir Produto"
                style="cursor: pointer"
                src="https://img.icons8.com/nolan/50/delete.png"
              />
            </button>
            <router-link v-bind:to="`/produtoDetalhe/${produto.id}`">
              <img
                title="Editar Produto"
                class="imgIcone"
                style="cursor: pointer"
                src="https://img.icons8.com/nolan/64/edit--v1.png"
              />
            </router-link>
          </td>
        </tr>
      </tbody>
      <t-foot v-else>
        <tr>
          <td>
            <h5>Nenhum produto encontrado</h5>
          </td>
        </tr>
      </t-foot>
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
      titulo: "Produtos",
      fornecedorId: this.$route.params.forn_id,
      fornecedor: {},
      nome: "",
      preco: "",
      codBarra: "",
      img: "",
      produtos: [],
    };
  },
  created() {
    if (this.fornecedorId) {
      this.carregarFornecedores();
      this.$http
        .get(`http://localhost:5000/api/produto/ByFornecedor/${this.fornecedorId}`)
        .then((res) => res.json())
        .then((produtos) => (this.produtos = produtos));
    } else {
      this.$http
        .get("http://localhost:5000/api/produto")
        .then((res) => res.json())
        .then((produtos) => (this.produtos = produtos));
    }
  },
  props: {},
  methods: {
    addProduto() {
      let _produto = {
        nome: this.nome,
        preco: this.preco,
        codBarra: this.codBarra,
        img: this.img,
        Fornecedor: {
          id: this.fornecedor.id,
          nome: this.fornecedor.nome,
        },
      };
      this.$http
        .post("http://localhost:5000/api/produto", _produto)
        .then((res) => res.json())
        .then((produto) => {
          this.produtos.push(produto);
          this.nome = "";
          this.preco = "";
          this.codBarra = "";
          this.img = "";
        });
    },
    remover(produto) {
      this.$http
        .delete(`http://localhost:5000/api/produto/${produto.id}`)
        .then(() => {
          let indice = this.produtos.indexOf(produto);
          this.produtos.splice(indice, 1);
        });
    },
    carregarFornecedores() {
      this.$http
        .get("http://localhost:5000/api/fornecedor/" + this.fornecedorId)
        .then((res) => res.json())
        .then((fornecedor) => {
          this.fornecedor = fornecedor;
          this.pegarQtdProdutosPorFornecedor();
        });
    },
  },
};
</script>

<style scoped>
input {
  border: 0.5px;
  border-color: #687f7f;
  border-radius: 5px;
  padding: 20px;
  font-size: 15px;
  color: #687f7f;
  display: inline;
  margin-right: 5px;
  height: 5px;
}
.inputs {
  margin-bottom: 10px;
  display: flex;
}
.inputCodBarra {
  display: grid;
  width: 40%;
}
.inputNome {
  display: grid;
  width: 40%;
}
.inputPreco {
  width: 28%;
  display: grid;
}
.inputImagem {
  display: block;
  margin-top: -14px;
}

.btnInput {
  padding: 10px;
  font-size: 0.9em;
  display: inline;
  background-color: #4682b4;
}
.btnInput:hover {
  padding: 10px;
  margin: 0px;
  border: 0px;
}
label {
  color: #4682b4;
}
</style>
