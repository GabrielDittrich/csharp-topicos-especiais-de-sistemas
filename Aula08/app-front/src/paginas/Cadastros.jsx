

function Cadastros(){

    function getFormulario(){
        return(
		<form>
			<label for="name">Nome</label>
			<input type="text" id="name" name="name" /> <br />
			<label for="cpf">CPF</label>
			<input type="text" id="cpf" name="cpf" multiple/> <br />
			<label for="telefone">Telefone</label>
            <input type="text" id="telefone" name="telefone" /> <br />
			<label for="email">E-mail</label>
			<input type="text" id="email" name="email" multiple/>
            <br />
            <br />
			<button>Salvar</button>
	  </form>
        );
    }

    function getTabela(){
        return (
            <table>
			<tr>
				<th>ID</th>
				<th>Nome</th>
				<th>CPF</th>
				<th>Ações</th>
			</tr>
			<tr>
				<td>1</td>
				<td>Maria</td>
				<td>12345</td>
				<td>
				   <button>Excluir</button>
					 <button>Editar</button>
				</td>
			</tr>
			<tr>
				<td>2</td>
				<td>Pedro</td>
				<td>34567</td>
				<td>
				   <button>Excluir</button>
					 <button>Editar</button>
				</td>
			</tr>
		</table>  
        );

    }
  
    return(
  <div>
        <h1>Formulário CRUD</h1>

        {getFormulario()}
        {getTabela()}
  </div>
    );
}

export default Cadastros;