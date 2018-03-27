/*Funciones Utilizadas en Vivero Market*/


function numeros(e)
{
tecla = (document.all) ? e.keyCode : e.which;
if (tecla<=13) return true;
patron =/\d/;
te = String.fromCharCode(tecla);
return patron.test(te);
}

function letras(e)
{
 tecla = (document.all) ? e.keyCode : e.which;
 if (tecla >45 && tecla <57)
 {return false;}

}

function unespacio(txt)
{
   var CharArray=txt.value.split('');
   for(var i=0;i<CharArray.length;i++)
   {
     if (CharArray[i] == " ")
     {			
		if (CharArray[i+1] == " ")
		{
			alert("Error, solo puede haber un espacio entre palabras");
			//txt.value = txt.value.replace (" ", "");			
			txt.value = txt.value.substring(0,txt.value.length-1);
			return false;	
		}		
	 }	 
   }
   return true;
}

function noespacio(txt)
{
   var CharArray=txt.value.split('');
   for(var i=0;i<CharArray.length;i++)
   {
     if (CharArray[i] == " ")
     {	
	    alert("Error, no se permiten espacios");		
		txt.value = txt.value.substring(0,txt.value.length-1);
		return false;
	 }
   }
   return true;
}

function numcoma(e)
{
tecla = (document.all) ? e.keyCode : e.which;
if (tecla<=13) return true;
if (tecla<=32) return false;
if (tecla<=44) return true;
patron =/\d/;
te = String.fromCharCode(tecla);
return patron.test(te);
}

function numpunto(e)
{
tecla = (document.all) ? e.keyCode : e.which;
if (tecla<=13) return true;
if (tecla<=44) return false;
if (tecla<=46) return true;
patron =/\d/;
te = String.fromCharCode(tecla);
return patron.test(te);
}