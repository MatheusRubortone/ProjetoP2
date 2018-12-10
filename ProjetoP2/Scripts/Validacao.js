function RetiraMascara(ObjCPF) {
    return ObjCPF.value.replace(/\D/g, '');
}

TestaCPF = function (strCPF) {
	strCPF = RetiraMascara(strCPF);
    var Soma;
    var Resto;
    Soma = 0;
	if (strCPF.length != 11 ||
		strCPF == "00000000000" ||
		strCPF == "11111111111" ||
		strCPF == "22222222222" ||
		strCPF == "33333333333" ||
		strCPF == "44444444444" ||
		strCPF == "55555555555" ||
		strCPF == "66666666666" ||
		strCPF == "77777777777" ||
		strCPF == "88888888888" ||
		strCPF == "99999999999") return false;

  for (i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
  Resto = (Soma * 10) % 11;
   
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)) ) return false;
   
  Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
   
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11) ) ) return false;
    return true;
}


function alerta (message) {
	$('#alertPlaceholder').html('<div class="alert alert-danger alert-dismissible fade show">'+message+'<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span></button></div>')
}

function ValidaLogin() {
    var login = document.getElementById("txtEmail");
    var senha = document.getElementById("txtSenha");

	//Valida Email
	if (login.value == "" || login.value.indexOf("@") < 1 || login.value.indexOf(".") < 1) {
		alerta("Email Inválido.");
		login.focus();
		return false;
	}

	//Valida Senha
	if (senha.value == "") {
		alerta("Insira sua senha.");
		senha.focus();
		return false;
	}
}

function somenteNumeros(evt){
	var charCode = (evt.which) ? evt.which : event.keyCode
	if (charCode > 31 && (charCode < 48 || charCode > 57))
		return false;
	return true;
}

function ValidaCadastro() {
    var codigo = document.getElementById("txtCodigo");
    var nome = document.getElementById("txtNome");
    var email = document.getElementById("txtEmail");
    var telefone = document.getElementById("txtTelefone");
	//var res = document.getElementById("fone2");
    var cpf = document.getElementById("txtCpf");
    var endereco = document.getElementById("txtEndereco");
	//var radioSim = document.getElementById("radioSim");
	//var radioNao = document.getElementById("radioNao");
	//var senha = document.getElementById("senhacad");
	//var senha2 = document.getElementById("senha2");
	//var cep = document.getElementById("cep");
	//var uf = document.getElementById("uf");
	//var cid = document.getElementById("municipio");

	var num = /[^0-9]/;


	//Valida Codigo
	if (codigo != null && codigo.value == "") {
		alerta("O preenchimento do campo Código é obrigatório!");
		codigo.focus();
		return false;
	}

	if(codigo !== null){
		// var num = /[^0-9]/;
		num.lastIndex = 0;
		if (num.test(codigo.value)) {
			alerta("Não são aceitos caracteres diferentes de números neste campo!");
			codigo.focus();
			return false;
		}
	}

	//Valida Nome
	if (nome.value == "") {
		alerta("O preenchimento do campo Nome é obrigatório!");
		nome.focus();
		return false;
	}

	if (nome.value.indexOf(' ') < 0) {
		alerta("É necessário fornecer o nome completo.");
		nome.focus();
		return false;
	}

	//Valida CPF
	if(!TestaCPF(cpf)){
		alerta("Digite um CPF válido!");
		cpf.focus();
		return false;
	}

	//Valida Email
	if (email.value == "") {
		alerta("O preenchimento do campo Email é obrigatório!");
		email.focus();
		return false;
	}

	if (email.value.length < 3 || email.value.indexOf(".") < 1 || email.value.indexOf("@") < 1) {
		alerta("Insira um email válido!");
		email.focus();
		return false;
	}

	//Valida Endereço
	if (endereco.value == "") {
		alerta("O preenchimento do campo Endereço é obrigatório!");
		endereco.focus();
		return false;
	}

	//Valida CEP
	//if(cep.value == "" || cep.value.length != 9){
	//	alerta("CEP Inválido!");
	//	cep.focus();
	//	return false;
	//}

	////Valida UF
	//if(uf.options[uf.selectedIndex].text == "UF *"){
	//	alerta("Selecione a UF!");
	//	uf.focus();
	//	return false;	
	//}

	////Valida cidade
	//if(cid.options[cid.selectedIndex].text == "Cidade *"){
	//	alerta("Selecione a Cidade!");
	//	cid.focus();
	//	return false;	
	//}

	////Valida Celular
	//num.lastIndex = 0;

	//var tel = telefone.value
	//tel = tel.replace(/\D/g, '');

	//if(tel == ""){
	//	alerta("O preenchimento do campo Telefone Celular é obrigatório!");
	//	telefone.focus();
	//	return false;
	//}

	//if (tel.length != 11 || num.test(tel)) {
	//	alerta("Insira um número de telefone válido!");
	//	telefone.focus();
	//	return false;
	//}	

	////Valida Residencial
	//if (res.value != ""){
	//	var telres = res.value
	//	telres = telres.replace(/\D/g, '');
	
	//	if (telres.length != 10 || num.test(telres)) {
	//		alerta("Insira um número de telefone residencial válido!");
	//		res.focus();
	//		return false;
	//	}	
	//}

	////Valida Radio
	//if(radioSim != null){
	//	if (radioSim.checked == false && radioNao.checked == false) {
	//		alerta("É necessário indicar se o cliente está Ativo ou Inativo!");
	//		return false;
	//	}
	//}

	//Valida Senha
	if(senha.value == "" || senha.value.length < 6){
		alerta("Digite uma senha com no mínimo 6 caracteres");
		return false;
	}
	if(senha2.value == ""){
		alerta("Digite novamente a senha");
		return false;
	}
	if(senha.value != senha2.value){
		alerta("As duas senhas não coincidem");
		return false;
	}
}

window.onresize = function () {
	if (window.innerWidth <= 700) {
		document.getElementById("maincol").classList.add('col-12');
		document.getElementById("maincol").classList.remove('col-8');
	} else {
		document.getElementById("maincol").classList.add('col-8');
		document.getElementById("maincol").classList.remove('col-12');
	}
}


$(document).ready(function () {

	if (window.innerWidth <= 700) {
		document.getElementById("maincol").classList.add('col-12');
		document.getElementById("maincol").classList.remove('col-8');
	} else {
		document.getElementById("maincol").classList.add('col-8');
		document.getElementById("maincol").classList.remove('col-12');
	}

    $('#xtCpf').mask('000.000.000-00', {reverse: false});
    $('#txtTelefone').mask('(00) 00000-0000');
	
});


