<template>
  <div>
    <Titulo texto="Sobre XPTO" />
    <p>
      XPTO é a demosntração de alguns recursos recursos do VUE Js. Um CRUD
      realizado com relacionamentos basicos. Foi criado Fornecedores e produtos
      pertencentes aos fornecedores. Nele é possivel adicionar produtos aos
      fornecedores. Possui botões actions, que facilitam a execução dos serviços
      implementados.
    </p>
    <p>
      O projeto foi componentizado, facilitando a reutilização dos mesmo. Foram
      criados os componentes, banco e recursos:
    </p>
    <li>
      <b>Nav : </b> Componente criados para o menu de navegação do projeto. Nele
      foi utilizado recursos de "router-link" para criar a navegação entre as
      telas através de rotas
    </li>
    <li>
      <b>Titulo : </b> Componente criado para Título, com finalidade de
      reutilização em todas as telas. Nele foi utilizado a diretiva @click para
      o botão Voltar, também para está funcionalidade, foi desenvolvido um
      method voltar(), e nele podemos usar o recurso "$router.back()".
    </li>
    <li><b>router.js : </b> Arquivo router, controle das rotas.</li>
    <li>
      <b>Produto : </b> Componente criado para cuidar das informações referentes
      aos produtos. Neste componente, foi possível aplicar algumas das
      diretivas, por exemplo, v-if,v-else,v-model,v-bind. Foram criados
      methos,addProduto(),remover(),carregarFornecedores(). Esses methods,
      podemos praticar os verbos, realizando as operações de GET,PUT,POST e
      DELETE.
    </li>
    <li>
      <b>ProdutoDetalhe : </b> Componente desenvolvido para cuidar dos detalhes
      do produto. Nele também foi utilizados os recursos das diretivas e
      aplicação dos verbos para alteração dos dados. Foram desenvolvidos
      recursos de edição do produto.
    </li>

    <li>
      <b>Fornecedor :</b> Componente criado para cuidar dos fornecedores. Assim
      como os componentes do produto, também foram aplicados os recursos das
      diretivas, rotas, verbos, importação de componentes entre outros recursos.
    </li>

    <li>
      <b>Banco.json</b> Criamos um banco fake com json-serve, para simularmos as
      ações. Nele criamos o relacionamento entre fornecedor e produto.
    </li>

    <p>
      A idéia do projeto era a aplicação das tecnicas de desenvolvimento
      utilizando os recursos da framework VUE JS. Foi aplicado algumas tecnicas
      utilizando recursos CSS, para que o layout pudesse ser mais amigável.
      Assim espero ter conseguido demosntrar um pouco dos conhecimentos
      relacionados.
    </p>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo.vue";
export default {
  components: {
    Titulo,
  },
};
</script>

<style scoped>
li, p {
  color:#4682b4;
  text-align: justify
}
</style>
