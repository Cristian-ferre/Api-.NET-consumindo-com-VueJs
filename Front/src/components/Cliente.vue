<script >
import axios from 'axios';

export default {
  name: 'funcionarios',
  props: {
    msg: String
  },
  data: () => {
    return {
      funcionarios: [],
      funcionario: { re: "", nomeFuncionario: "", email: "", ramal: "", imagem: "" },
      mensagem: ""
    }
  },
  methods: {
    abrirModal() {
      this.$refs['meu-modal'].show()
    },
    fecharModal() {
      this.$refs['meu-modal'].hide()
    },
    lista() {
      axios.get(`https://localhost:7129/Intranet`).then((res) => {
        this.funcionarios = res.data
      })
    },

    salvar() {
      if (this.funcionario.id) {
        this.alterar()
        return
      }
      axios.post(`https://localhost:7129/Intranet/Cadastrar`, this.funcionario).then(() => {
        this.lista()
      })
    },
    excluir(id) {
      if (confirm("Confirma a exclusão? ")) {
        axios.delete(`https://localhost:7129/Intranet/${id}`).then(() => {
          this.lista()
        })
      }
    },
    //mostra na tela
    editar(funcionario) {

      this.funcionario = funcionario
    },//esse envia
    alterar() {
      axios.put(`https://localhost:7129/Intranet/${this.funcionario.id}`, this.funcionario)
        .then(() => {
          this.lista()
          this.funcionario = { re: "", nomeFuncionario: "", email: "", ramal: "", imagem: "" }
        })
    }
  },
  created() {
    this.lista()
  }
}

</script>

<template>

  <div>
    <form>
      <div class="form-row">
        <div class="form-group col-md-6">
          <label for="Re">RE</label>
          <input type="hidden" id="id" name="id">
          <input type="text" class="form-control" v-model="funcionario.re" id="Re" name="Re" placeholder="Re">
        </div>
        <div class="form-group col-md-6">
          <label for="Ramal">Ramal</label>
          <input type="text" class="form-control" v-model="funcionario.ramal" id="Ramal" name="Ramal"
            placeholder="Ramal">
        </div>
      </div>
      <div class="form-group">
        <label for="Email">Email</label>
        <input type="email" class="form-control" v-model="funcionario.email" id="Email" name="Email"
          placeholder="Email">
      </div>
      <div class="form-group">
        <label for="Nome">Nome</label>
        <input type="text" class="form-control" v-model="funcionario.nomeFuncionario" id="Nome" name="Nome"
          placeholder="Nome">
      </div>
      <div class="form-group">
        <label for="Imagem">Imagem</label>
        <input type="text" class="form-control" v-model="funcionario.imagem" id="Imagem" name="Imagem"
          placeholder="Imagem">
      </div>
      <hr />
      <button v-on:click="salvar()" type="button" class="btn btn-primary">Cadatrar</button>

      <div style="color: red">
        {{ mensagem }}
      </div>



    </form>
    <table class="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Re</th>
          <th>Nome</th>
          <th>Email</th>
          <th>Ramal</th>
          <th>Imagem</th>
          <th colspan="2"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="funcionario in funcionarios" v-bind:key="funcionario.id">
          <td>{{ funcionario.id }}</td>
          <td>{{ funcionario.re }}</td>
          <td>{{ funcionario.nomeFuncionario }}</td>
          <td>{{ funcionario.email }}</td>
          <td>{{ funcionario.ramal }}</td>
          <td>{{ funcionario.imagem }}</td>
          <td><button class="btn btn-primary" v-on:click="editar(funcionario)">Editar</button></td>
          <td><button class="btn btn-danger" v-on:click="excluir(funcionario.id)">Excluir</button></td>
        </tr>
      </tbody>
    </table>
    <div>
      <b-button @click="abrirModal">Abrir Modal</b-button>
      <b-button @click="fecharModal">Fechar Modal</b-button>
      <b-modal ref="meu modal"></b-modal>
    </div>
  </div>



</template>
<style scoped>

</style>
