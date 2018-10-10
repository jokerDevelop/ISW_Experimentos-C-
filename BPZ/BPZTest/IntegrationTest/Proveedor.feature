Feature: Mantenimiento de Proveedor
	Yo como Personal de RRHH deseo gestionar proveedores, para tener un mejor 
  manejo de la informacion.

@mytag
Scenario: Registrar Proveedor
		Given luego de iniciar sesion en la aplicacion
		When 	hago clic en el enlace de Proveedores
		And 	luego hago click en el boton de Registro
		And 	en la nueva pantalla escribo en campo nombre el valor de "Petro Peru"
		And 	hago click en el boton de Guardar
		Then 	el sistema muestra un mensaje de "Se registro correctamente el Proveedor"


Scenario: Actualizar Proveedor
		Given luego de iniciar sesion en la aplicacion
		When 	hago clic en el enlace de Proveedores
		And 	busco el Proveedor de id "1" para seleccionarlo
		And 	luego hago click en el boton de Editar
		And 	en la nueva pantalla escribo en campo nombre el valor de "Petro Peru SAC"
		And 	hago click en el boton de Guardar
		Then 	el sistema muestra un mensaje de "Se actualizo correctamente el Proveedor"


Scenario: Listar Proveedor
		Given luego de iniciar sesion en la aplicacion
		When 	hago clic en el enlace de Proveedores
		Then 	la nueva pantalla muestra la lista de Proveedores


Scenario: Eliminar Proveedor
		Given luego de iniciar sesion en la aplicacion
		When 	hago clic en el enlace de Proveedores
		Then  la nueva pantalla muestra la lista de Proveedores
		When  hago clic en el boton de Eliminar el Proveedor con el id "1" 
		Then  el sistema muestra un mensaje de "Se elimino el Proveedor" 