<template>
  <div>
    <div>
      <table>
        <thead>
          <th>
            <h1 class="titulo">{{ texto }}</h1>
          </th>
          <th>
            <div class="voltar">
              <img
                src="https://img.icons8.com/nolan/64/undo.png"
                class="btnVoltar"
                title="Voltar"
                style="cursor: pointer"
                @click="voltar()"
              />
            </div>
          </th>
        </thead>
      </table>
    </div>
    <hr color="#4682B4" width="100%" size="3" align="left" />
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
  },
  methods: {
    voltar() {
      this.$router.back();
    },
  },
};
</script>

<style scoped>
.titulo {
  color: #4682b4;
  margin-bottom: 1px;
  width: 70%;
  background-color: #eee;
  text-align: initial;
}

table thead th {
  background-color: #eee !important;
  font-size: 1em;
  font-weight: 500;
  padding: 10px 0px;
  text-align: center !important;
  padding: 5px 5px 5px 5px;
}
.voltar {
  width: "50%";
}

.btnVoltar {
  float: right;
}
</style>
