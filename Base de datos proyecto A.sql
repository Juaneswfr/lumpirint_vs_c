create database LumiPrint
use LumiPrint


--------------------------------------------------------------TABLA CARGO-------------------------------------------------------------
create table Cargo 
(
Nombre_cargo Varchar (50) primary key not null,
Descripcion_cargo Text not null,
Salario_cargo Decimal not null
)

Insert into Cargo values ('Gerente', 'Gestiona la productividad de la empresa', 3000000)
Insert into Cargo values ('Contador', 'Mantiene al tanto de todas las financiaciones de la empresa', 2000000)
Insert into Cargo values ('Administrador','Administra el proceso de los empleados', 1200000)
Insert into Cargo values ('Diseñador', 'Diseña y realiza las ventas', 781242)

--------------------------------------------------------------TABLA EMPLEADOS-------------------------------------------------------
//---Crear Tabla Empleados---\\
create table Empleado
(
Id_em bigint identity (1,1)not null,
No_Documento_em Bigint primary key not null,
Nombre_em  Varchar (50) not null,
Apellido_em  Varchar (50) not null,
Celular_em  Bigint not null,
Telefono_em Bigint null,
Direccion_em  Varchar(50) not null,
Correo_em  Varchar (50) not null,
Estado_em  Varchar(50) not null,
Nombre_cargo Varchar (50) foreign key references Cargo (Nombre_cargo)
)

//---Procedimiento Almacenado para consultar Empleado por Nombre,Documento o Cargo---\\
create procedure Consultar_Empleado
@Consulta nvarchar(20)
AS
select Id_em,Nombre_Em,No_Documento_em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em,Nombre_cargo from Empleado
where Nombre_em Like'%'+@Consulta+'%' or Nombre_cargo='%'+@Consulta+'%' or No_Documento_em like'%'+@Consulta+'%'
//---Procedimiento Almacenado para registrar Empleado---\\
create procedure Registrar_Empleado
@No_Documento_em Bigint,@Nombre_Em Varchar (50),@Apellido_Em Varchar (50),@Celular_Em Bigint,@Telefono_em Bigint,@Direccion_Em Varchar (50),@Correo_Em Varchar (50), @Estado_em Varchar (50),@Nombre_Cargo Varchar (50)
AS
Insert into Empleado(No_Documento_em,Nombre_Em,Apellido_Em,Celular_Em,Telefono_em,Direccion_Em,Correo_Em, Estado_em,Nombre_Cargo) values (@No_Documento_em,@Nombre_Em,@Apellido_Em,@Celular_Em,@Telefono_em,@Direccion_Em,@Correo_Em,@Estado_em,@Nombre_Cargo)
//---Procedimiento Almacenado para actualizar Empleado---\\
create procedure Actualizar_Empleado
@No_Documento_em Bigint,@Nombre_Em Varchar (50),@Apellido_Em Varchar (50),@Celular_Em Bigint,@Telefono_em Bigint,@Direccion_Em Varchar (50),@Correo_Em Varchar (50), @Estado_em Varchar (50),@Nombre_Cargo Varchar (50),@Id_em Bigint
AS
Update Empleado set No_Documento_em= @No_Documento_em,Nombre_Em= @Nombre_Em,Apellido_Em= @Apellido_Em, Celular_Em= @Celular_Em,Telefono_em= @Telefono_em,Direccion_Em= @Direccion_Em,Correo_Em= @Correo_Em, Estado_em= @Estado_em,Nombre_Cargo= @Nombre_Cargo
Where Id_em =@Id_em

Execute Registrar_Empleado 1, 'Felipe', 'Stronger', 7555249, 3138283316,'64 Sur2 Cra. 87c', 'FelipeStronger@gmail.com', 'Activo', 'Gerente'
Execute Registrar_Empleado 2, 'Juan', 'Ramirez',7194899, 3195941442, 'Cra 78H #60-A32Sur', 'juanestebanramirezavila@gmail.com', 'Activo', 'Contador'
execute Registrar_Empleado 3, 'Felipe', 'Corredor', 7154220, 3195789442, '58 Sur1 Tv. 87c', 'Felipecorredor@gmail.com', 'Activo', 'Diseñador'
execute Registrar_Empleado 4, 'Juan', 'Smith',7190049, 3137941442, '62 Sur98 Cra. 87 Bi', 'JuanEstebansmithwalker@gmail.com', 'Activo', 'Administrador'


--------------------------------------------------------------TABLA PROVEEDOR------------------------------------------------------------

create table Proveedor
(
Id_Prov Bigint identity(1,1) primary key  not null,
Empresa Varchar (50)not null,
Nit_Prov Bigint not null,
Telefono_Prov  Bigint not null,
Correo_Prov Varchar(50) not null,
Estado_Prov Varchar(50) not null
)
select * from proveedor
------------------------------------------------------
create procedure Registrar_Proveedor
@Empresa Varchar(50),@Nit_Prov Bigint,@Telefono_Prov Bigint,@Correo_Prov Varchar (50),@Estado_Prov Varchar(50)
AS
Insert into Proveedor (Empresa, Nit_Prov, Telefono_Prov, Correo_Prov, Estado_Prov) values (@Empresa,@Nit_Prov,@Telefono_Prov,@Correo_Prov,@Estado_Prov)
//---Procedimiento Almacenado para consultar Proveedor por Nombre,Documento o Cargo---\\
create procedure Consultar_Proveedor
@Consulta nvarchar(20)
AS
select Id_Prov,Empresa,Nit_Prov,Telefono_Prov,Correo_Prov,Estado_Prov from Proveedor
where Empresa Like'%'+@Consulta+'%' or Estado_Prov='%'+@Consulta+'%' or Nit_Prov Like'%'+@Consulta+'%'
//---Procedimiento Almacenado para actualizar Proveedor---\\
create procedure Actualizar_Proveedor
@Telefono_Prov Bigint, @Correo_Prov Varchar(50),@Estado_Prov Varchar(50), @Id_Prov Bigint
AS
Update Proveedor set Telefono_Prov= @Telefono_Prov, Correo_Prov= @Correo_Prov, Estado_Prov= @Estado_Prov
Where Id_Prov =@Id_Prov

update Proveedor set Estado_Prov='Inactivo'
where Estado_Prov=''
----------------------------------------------------------------
Execute Registrar_Proveedor 'Luki',7191249,101108691,'Luki@gmail.com','Activo'
Execute Registrar_Proveedor 'Stung',7891249,108908691,'Stung@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Stronger',7893649,101169691,'Stronger@gmail.com','Activo'
Execute Registrar_Proveedor 'Puiyi',7893660,101169640,'Puiyi@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Omega',2793660,951169640,'Omega@gmail.com','Activo'
Execute Registrar_Proveedor 'Jastu',27911660,956669640,'Jastu@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Madecentro',27917760,956687640,'Madecentro@gmail.com','Activo'
Execute Registrar_Proveedor 'Metalcentro',27917440,9567640,'Metalcentro@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Diseñors',27917760,956687640,'Diseñors@gmail.com','Activo'
Execute Registrar_Proveedor 'Bondsi',36917440,116764065,'Bondsi@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Cartusx',42977760,959528764,'Cartusx@gmail.com','Activo'
Execute Registrar_Proveedor 'Marcoks',36877440,110064065,'Marcoks@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Zorks',42979960,953228764,'Zorks@gmail.com','Activo'
Execute Registrar_Proveedor 'Ltus',36877489,110064023,'Ltus@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Klus',98979960,763228764,'Klus@gmail.com','Activo'
Execute Registrar_Proveedor 'Ltalidud',32277489,110344023,'Ltalidud@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Tritrus',98900960,163228764,'Tritrus@gmail.com','Activo'
Execute Registrar_Proveedor 'Portug',32270389,111544023,'Portug@gmail.com','Inactivo'
Execute Registrar_Proveedor 'Ffaur',94600960,179228764,'Ffaur@gmail.com','Activo'
Execute Registrar_Proveedor 'Rutistuco',32270389,111544023,'Rutistuco@gmail.com','Inactivo'
Execute Registrar_Proveedor 'FTsor',93640940,122828764,'FTsor@gmail.com','Activo'
Execute Registrar_Proveedor 'KSAW',46204100,101743725,'KSAW@gmail.com','Inactivo'
Execute Registrar_Proveedor 'FStasw',94980960,131248711,'FStasw@gmail.com','Activo'
Execute Registrar_Proveedor 'Fenrhir',70094140,112854411,'Fenrhir@gmail.com','Inactivo'
Execute Registrar_Proveedor 'FTSA',36600920,132428764,'FTSA@gmail.com','Activo'
Execute Registrar_Proveedor 'TTTriplex',7014040,110054311,'TTTriplex@gmail.com','Inactivo'
Execute Registrar_Proveedor 'FLSO',87580914,153528743,'FLSO@gmail.com','Activo'
Execute Registrar_Proveedor 'Marcos LTA',7074747,110151311,'Marcos_LTA@gmail.com','Inactivo'
Execute Registrar_Proveedor 'SAXRQ',42320160,153228723  ,'SAXRQ@gmail.com','Activo'
Execute Registrar_Proveedor 'VPlotF',7448487,122122341,'VPlotF@gmail.com','Inactivo'

--------------------------------------------------------------TABLA_INVENTARIO------------------------------------------------------------

create table Inventario
(
Id_pz Bigint identity(1,1) primary key  not null,
Tipo_de_pieza Varchar(50)not null,
Descripcion Text not null,
Tamaño Varchar(50) null,
Cantidad_existente Bigint not null,
Valor_Proveedor Decimal not null,
Id_Prov Bigint foreign key references Proveedor(Id_Prov),
Empresa Varchar(50) not null
)

select * from Inventario

//---Procedimiento Almacenado para consultar Inventario por Nombre,Documento o Cargo---\\
create procedure Consultar_Materia_Prima
@Consulta nvarchar(20)
AS
select Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Proveedor,Empresa,Id_pz,Id_Prov from Inventario 
where Tipo_de_pieza Like'%'+@Consulta+'%' or Empresa Like'%'+@Consulta+'%' or Id_pz Like'%'+@Consulta+'%'

//---Procedimiento Almacenado para Registrar Inventario---\\
create procedure Registrar_Materia_Prima
@Tipo_de_pieza Varchar(50),@Descripcion Text,@Tamaño Varchar(50),@Cantidad_Existente Bigint,@Valor_Proveedor Decimal, @Id_Prov Bigint,@Empresa Varchar(50)
As
Insert into Inventario (Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Proveedor,Id_Prov,Empresa) values (@Tipo_de_pieza,@Descripcion,@Tamaño,@Cantidad_Existente,@Valor_Proveedor,@Id_Prov,@Empresa)

//---Procedimiento Almacenado para actualizar Inventario---\\
create procedure Actualizar_Materia_Prima
@Tipo_de_pieza Varchar(50),@Descripcion Text,@Tamaño Varchar(50),@Cantidad_Existente Bigint ,@Valor_Proveedor Decimal ,@Empresa Varchar(50),@Id_Prov Bigint,@Id_pz Bigint
AS
Update Inventario set Tipo_de_pieza= @Tipo_de_pieza,Descripcion= @Descripcion,Tamaño= @Tamaño,Cantidad_Existente= @Cantidad_Existente,Valor_Proveedor= @Valor_Proveedor,Empresa= @Empresa,Id_Prov=@Id_Prov
Where Id_pz =@Id_pz

Execute Registrar_Materia_Prima 'Lonas','Textil','20x20',5,3000,1,'Luki'
Execute Registrar_Materia_Prima 'Vinilo','De Colores','20x20',5,1500,1,'Luki'
Execute Registrar_Materia_Prima 'Acetato','Trasparente','20x20',5,1800,2,'Stung'
Execute Registrar_Materia_Prima 'Madera','Rigida','20x20',5,1700,2,'Stung'
Execute Registrar_Materia_Prima 'Banner','Lona','20x20',5,5000,5,'Omega'
Execute Registrar_Materia_Prima 'Black OUP','Loca','20x20',5,7000,5,'Omega'
Execute Registrar_Materia_Prima 'PanaFlex','De Colores','20x20',5,1000,7,'Madecentro'
Execute Registrar_Materia_Prima 'Imantado','De Colores','20x20',5,3000,7,'Madecentro'
Execute Registrar_Materia_Prima 'Opalina','Papel','20x20',5,2000,8,'Metalcentro'
Execute Registrar_Materia_Prima 'Papel Fotografico','Textil','20x20',5,3500,8,'Metalcentro'
Execute Registrar_Materia_Prima 'Lienzo','Papel','20x20',5,2800,10,'Bondsi'
Execute Registrar_Materia_Prima 'Topezones','Maderas','20x20',5,3600,10,'Bondsi'
Execute Registrar_Materia_Prima 'Retablos','Maderas','20x20',5,1200,12,'Marcoks'
Execute Registrar_Materia_Prima 'Poliestireno','Rigidos','20x20',5,1500,12,'Marcoks'
Execute Registrar_Materia_Prima 'Acrilico','Textil Rigido','20x20',5,4700,14,'Ltus'

--------------------------------------------------------------TABLA-PEDIDO_COMPRA------------------------------------------------------------
create table Pedido_Compra
(
Id_Pc Bigint primary key not  null,
Fecha_Realizacion_Pc datetime  not null,
Fecha_Entrega_Pc datetime  not null,
Valor_Total_Pc Bigint not null,
Subtotal_Pc Bigint not null,
Iva_Pc Bigint  not null,
Estado_Pc Varchar(50)not null ,
Id_Prov Bigint foreign key references Proveedor(Id_Prov),
Empresa Varchar (50) not null
)
//---Procedimiento Almacenado para consultar Pedido de Compra por medio de su Fecha de realización o de entrega---\\
create procedure Consultar_Pedido_Compra_Fecha
@Consulta nvarchar(50)
AS
declare @Fecha datetime, @Fecha_Mas_Uno datetime
select @Fecha = convert(datetime,@Consulta, 102)
select @Fecha_Mas_Uno = dateadd(dd, 1, @Fecha)
select Id_Pc,Fecha_Realizacion_Pc,Fecha_Entrega_Pc,Valor_Total_Pc,Subtotal_Pc,Iva_Pc,Id_Prov,Empresa,Estado_Pc from Pedido_Compra  
where Fecha_Realizacion_Pc >= @Fecha and Fecha_Realizacion_Pc < @Fecha_Mas_Uno or Fecha_Entrega_Pc=convert(datetime,@Consulta, 121)
//---Procedimiento Almacenado para consultar Pedido de Compra por medio de su Empresa o Id de compra---\\
create procedure Consultar_Pedido_Compra
@Consulta nvarchar(20)
AS
select Id_Pc,Fecha_Realizacion_Pc,Fecha_Entrega_Pc,Valor_Total_Pc,Subtotal_Pc,Iva_Pc,Id_Prov,Empresa,Estado_Pc from Pedido_Compra 
where Id_Pc Like'%'+@Consulta+'%' or Empresa Like'%'+@Consulta+'%'
//---Procedimiento Registrar Pedido de compra---\\
create procedure Registrar_Pedido_Compra
@Id_Pc Bigint,@Fecha_Realizacion_Pc datetime,@Fecha_Entrega_Pc datetime,@Valor_Total_Pc Bigint,@Subtotal_Pc Bigint,@Iva_Pc Bigint,@Id_Prov Bigint,@Empresa Varchar(50),@Estado_Pc Varchar(50)
As
Insert into Pedido_Compra (Id_Pc,Fecha_Realizacion_Pc,Fecha_Entrega_Pc,Valor_Total_Pc,Subtotal_Pc,Iva_Pc,Id_Prov,Empresa,Estado_Pc) values (@Id_Pc,@Fecha_Realizacion_Pc,@Fecha_Entrega_Pc,@Valor_Total_Pc,@Subtotal_Pc,@Iva_Pc,@Id_Prov,@Empresa,@Estado_Pc)
//---Procedimiento Almacenado para Actualizar Pedido de compra---\\
create procedure Actualizar_Pedido_Compra
@Fecha_Realizacion_Pc datetime,@Fecha_Entrega_Pc datetime,@Valor_Total_Pc Bigint,@Subtotal_Pc Bigint,@Iva_Pc Bigint ,@Empresa Varchar(50),@Id_Prov Bigint,@Estado_Pc Varchar(50), @Id_Pc Bigint
AS
Update Pedido_Compra set Fecha_Realizacion_Pc=@Fecha_Realizacion_Pc,Fecha_Entrega_Pc=@Fecha_Entrega_Pc, Valor_Total_Pc=@Valor_Total_Pc, Subtotal_Pc=@Subtotal_Pc, Iva_Pc=@Iva_Pc,Empresa=@Empresa,Id_Prov=@Id_Prov,Estado_Pc=@Estado_Pc
where Id_Pc=@Id_Pc
//---Procedimiento Almacenado para Actualizar Pedido de compra---\\
create procedure Actualizar_Pedido_Compra_Dos
@Estado_Pc Varchar(50), @Id_Pc Bigint
AS
Update Pedido_Compra set Estado_Pc=@Estado_Pc
where Id_Pc=@Id_Pc


select * from Pedido_Compra
----------------------------------------------------------TABLA-PEDIDO_COMPRA_INVETARIO------------------------------------------------------------

create table Pedido_Comp_Inv_Prov
(
IdPCIV Bigint primary key identity(1,1) not null,
Id_Pc  Bigint foreign key references Pedido_Compra(Id_Pc) not null,
Id_pz Bigint foreign key references Inventario(Id_pz) not null,
Id_Prov Bigint foreign key references Proveedor(Id_Prov)not null,
Tipo_de_pieza varchar(50)not null,
Descripcion text not null,
Tamaño varchar(50) not null,
CantidadPedido Bigint not null,
Valor_Proveedor Decimal not null,
ValorTotalProv Decimal not null,
Empresa Varchar (50) not null
)
select * from 
//---Trigger para aumentar en la Cantidad Existente del Inventario por medio de la cantidad comprada---\\
Create Trigger InventarioCantMas on Pedido_Comp_Inv_Prov
for insert
as
Update Inventario set Inventario.Cantidad_existente=Inventario.Cantidad_existente+D.CantidadPedido 
from Inventario as Inventario inner join INSERTED
as D on D.Id_pz = Inventario.Id_pz

//---Trigger para disminuir la Cantidad Existente de el Inventario por medio de la cantidad comprada---\\
Create Trigger InventarioCantMen on Pedido_Comp_Inv_Prov
for delete
as
Update Inventario set Inventario.Cantidad_existente=Inventario.Cantidad_existente-D.CantidadPedido 
from Inventario as Inventario inner join DELETED
as D on D.Id_pz = Inventario.Id_pz
----------------------------------------------------------TABLA_MAQUINARIA------------------------------------------------------------
//---Crear la tabla Maquinaria---\\
Create table Maquinaria
(
Id_Ma Bigint primary key identity(1,1) not null,
Tipo_Ma Varchar (50) not null,
Garantia Varchar (50)not null,
NumeroReparacion Bigint not null,
Mantenimiento Varchar (50) not null,
Estado_Ma Varchar (50) not null
)


//---Procedimiento Almacenado para consultar Inventario por Nombre,Documento o Cargo---\\
create procedure Consultar_Maquinaria
@Consulta nvarchar(20)
AS
select Id_Ma,Tipo_Ma,Garantia,NumeroReparacion,Mantenimiento,Estado_Ma from Maquinaria 
where Tipo_Ma Like'%'+@Consulta+'%' or Id_Ma Like'%'+@Consulta+'%' or Estado_Ma Like'%'+@Consulta+'%'
//---Procedimiento Almacenado para registrar Inventario---\\
create procedure Registrar_Maquinaria
@Tipo_Ma Varchar (50),@Garantia Varchar (50),@NumeroReparacion Bigint,@Mantenimiento Varchar (50),@Estado_Ma Varchar (50) 
as
Insert into Maquinaria (Tipo_Ma,Garantia,NumeroReparacion,Mantenimiento,Estado_Ma)values(@Tipo_Ma,@Garantia,@NumeroReparacion,@Mantenimiento,@Estado_Ma)
//---Procedimiento Almacenado para actualizar Inventario---\\
create procedure Actualizar_Maquinaria
@Tipo_Ma Varchar (50),@Garantia Varchar (50),@NumeroReparacion Bigint,@Mantenimiento Varchar (50),@Estado_Ma Varchar (50), @Id_Ma bigint 
AS
Update Maquinaria set Tipo_Ma= @Tipo_Ma,Garantia= @Garantia,NumeroReparacion= @NumeroReparacion,Mantenimiento= @Mantenimiento,Estado_Ma= @Estado_Ma
Where Id_Ma= @Id_Ma

Execute Registrar_Maquinaria 'Ordenador 1','1 año a 2 años',27712892,'No dispone','Funcionando'
Execute Registrar_Maquinaria 'Ordenador 2','Garantía expirada',27712892,'Limpieza','Funcionando'
Execute Registrar_Maquinaria 'Impresora Plotter 1','2 años a 4 años',55475643,'Cartuchos agotados','Funcionando'
Execute Registrar_Maquinaria 'Impresora Plotter 2','2 años a 4 años',55475643,'No dispone','Funcionando'
Execute Registrar_Maquinaria 'Impresora Laser 1','6 meses a 12 meses',37784254,'No dispone','Funcionando'
 

--------------------------------------------------------------TABLA_CLIENTE------------------------------------------------------------
//---Crear la tabla Cliente---\\
create table Cliente
(
No_Documento_Cl Bigint primary key not null,
Tipo_Identificacion_Cl Varchar (50) not null,
Nombre_Cl Varchar(50) not null,
Apellido_Cl Varchar (50) not null,
Celular_Cl Bigint not null,
Direccion_Cl Varchar (50) not null,
Correo_Cl Varchar (50) not null
)

insert into Cliente values (1000123905, 'Cedula', 'Anderson', 'Carrranza', 3209113682, 'avenida siempre viva', 'asdas@gmail.com')

select * from Cliente

//---Crear procedimiento almacenado para Registrar Cliente --\\
create procedure Registrar_Cliente
@No_Documento_CL Bigint,@Tipo_Identificacion_Cl Varchar (50),@Nombre_Cl Varchar (50),@Apellido_Cl Varchar (50),@Celular_Cl Bigint,@Direccion_Cl Varchar (50),@Correo_Cl Varchar (50)
AS
Insert into Cliente (No_Documento_Cl, Tipo_Identificacion_Cl, Nombre_Cl, Apellido_Cl, Celular_Cl, Direccion_Cl, Correo_Cl) values (@No_Documento_Cl,@Tipo_Identificacion_Cl,@Nombre_Cl,@Apellido_Cl,@Celular_Cl,@Direccion_Cl,@Correo_Cl)
--------------------------------------------------------------TABLA-PEDIDO_CLIENTE------------------------------------------------------------
create table Pedido_Cliente
( 
Id_Pcli Bigint primary key  not null,
Fecha_Realizacion_Pcli datetime not null,
Fecha_Entrega_Pcli  datetime not null,
Observaciones Text not null,
Iva_Pcli Bigint not null, 
Subtotal_Pcli Bigint not null,
Valor_Total_Pcli Bigint not null,
No_Documento_em Bigint foreign key references Empleado (No_Documento_em) not null,
Nombre_em  Varchar (50) not null,
Apellido_em Varchar (50) not null,
No_Documento_Cl Bigint foreign key references Cliente (No_Documento_Cl) not null,
Nombre_Cl Varchar(50) not null,
Apellido_Cl Varchar(50) not null,
Abono_Pcli Bigint not null,
Saldo_Pcli Bigint not null,
Estado_Pcli Varchar (30)not null
)
select * from Pedido_Cliente where No_Documento_Cl=423432
--------------------------------------------------------------TABLA_PRODUCCION------------------------------------------------------------
create table Produccion
(
Id_Produccion Bigint primary key not null,
Id_Ma Bigint  foreign key references Maquinaria(Id_Ma) not null,
Tipo_Ma Varchar (50) not null,
Nombre_Producto Varchar(50) not null,
Valor_Producto Bigint not null,
Tamaño Varchar(50) not null,
Descripcion Varchar(50) not null,
Empresa Varchar(50) not null
)
select * From produccion
--------------------------------------------------------------TABLA_PEDIDO_CLIENTE_PRODUCCION------------------------------------------------------------

create table PedidoCliente_Produc
(
Id_PeInv Bigint primary key identity(1,1) not null,
Id_Pcli Bigint foreign key references Pedido_Cliente(Id_Pcli) not null,
Id_Produccion Bigint foreign key references Produccion(Id_Produccion) not null,
Cantidad_PeInv Bigint not null,
Valor_Total_PeInv Decimal not null
)


-------------------------------------------------------TABLA_PRODUCCION_INVENTARIO------------------------------------------------------------

create table Produc_Invent
(
Id_PROINV Bigint primary key identity(1,1) not null,
Cantidad_Necesitada Bigint not null,
Id_Produccion Bigint foreign key references Produccion(Id_Produccion) not null,
Id_pz Bigint foreign key references Inventario(Id_pz) not null,
Tipo_de_pieza Varchar(50)not null
)

//---Trigger para disminuir la Cantidad Existente de el Inventario por medio de la Cantidad Necesitada---\\
Create Trigger InventarioCantMenProduc on Produc_Invent
for insert
as
Update Inventario set Inventario.Cantidad_existente=Inventario.Cantidad_existente-D.Cantidad_Necesitada 
from Inventario as Inventario inner join INSERTED
as D on D.Id_pz = Inventario.Id_pz
Print 'Se ha disparado el Trigger'
--------------------------------------------------------------FIN TABLAS------------------------------------------------------------
------------------------------------------------------------------------------------SENTENCIAS-------------

select Id_pc,Fecha_Realizacion_Pc, Inventario.Id_Pz,Tipo_de_pieza,Descripcion,Cantidad_Comprada_Pc,Valor_Proveedor,Valor_Total_Prov,Proveedor.Empresa from Pedido_Compra Inner Join Proveedor on Pedido_Compra.Empresa=Proveedor.Empresa Inner Join Inventario on Pedido_Compra.Id_pz=Inventario.Id_pz

select Id_Pc, Inventario.Id_Pz, Cantidad_Comprada_Pc,Proveedor.Empresa, Tipo_de_pieza, Descripcion, Valor_Producto from Pedido_Compra, Proveedor,Inventario where Pedido_Compra.Empresa=Proveedor.Empresa and Pedido_Compra.Id_pz=Inventario.Id_pz


Select IdPCIV, Id_Pc,Inventario.Id_Pz,CantidadPedido, ValorTotalProv,Proveedor.Empresa, Tipo_de_pieza from Pedido_Comp_Inv_Prov Inner Join Inventario on Pedido_Comp_Inv_Prov.Id_pz = Inventario.Id_pz Inner Join Proveedor on Pedido_Comp_Inv_Prov.Empresa =Proveedor.Empresa 
Select IdPCIV, Id_Pc,Inventario.Id_Pz, Tipo_de_pieza, Descripcion, CantidadPedido, ValorTotalProv,Proveedor.Empresa from Pedido_Comp_Inv_Prov Inner Join Inventario on Pedido_Comp_Inv_Prov.Id_pz = Inventario.Id_pz Inner Join Proveedor on Pedido_Comp_Inv_Prov.Empresa =Proveedor.Empresa  
select * from pedido_compra where Fecha_Realizacion_Pc >0

select Id_Pc,Fecha_Realizacion_Pc,Fecha_Entrega_Pc,Valor_Total_Pc,Subtotal_Pc,Iva_Pc,Empresa from Pedido_Compra where Id_Pc = 1

----------------------------------

select Empresa from Proveedor
Alter table Produccion Add foreign key (Tipo_de_pieza) references Materia_Prima(Tipo_de_pieza)
Alter table Produccion Add foreign key (Id_Ma) references Maquinaria(Id_Ma)
Alter table Produccion Add foreign key (Id_Em) references Empleado(Id_Em)
----------------------------------
select * from Empleado
Update Empleado set No_Documento_em= '{0}',Nombre_Em= '{1}',Apellido_Em= '{2}', Celular_Em= '{3}',Telefono_em= '{4}',Direccion_Em= '{5}',Correo_Em= '{6}', Estado_em= '{7}',Nombre_Cargo= '{8}' where Id_em={9}
Delete from Empleado where No_Documento_em='0'
Select Nombre_em from empleado
update Empleado set Estado_em='Activo' where Nommbre = 'Felipe'
select Id_em,Nombre_Em,No_Documento_em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em,Nombre_cargo from Empleado where Nombre_em Like'%{0}%'
select Id_em, No_Documento_em,Nombre_Em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em from Empleado where Nombre_em Like'%{0}%'
select Id_em, No_Documento_em,Nombre_Em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em, Nombre_Cargo from Empleado where Nombre_em Like'%j%'


select * from Iniciar_Sesion
select * from Proveedor
select * from Pedido_Cliente
select * from Cliente
select * from Pedido_Compra
select * from Maquinaria
Update Empleado set No_Documento_em= 123,Nombre_Em= 'Nathaly',Apellido_Em= 'Perez', Celular_Em= 123,Telefono_em= 123,Direccion_Em= 'tyuty',Correo_Em= 'hughu', Estado_em= 'Inactivo',Nombre_Cargo= 'Gerente'where Id_em= 26
Insert into Empleado (No_Documento_em,Nombre_Em,Apellido_Em,Celular_Em,Telefono_em,Direccion_Em,Correo_Em, Estado_em,Nombre_Cargo)values(7,'uj','a',33424,52352354,'xd','xd','Activo','Contador')
select Id_em,Nombre_Em,No_Documento_em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em,Nombre_cargo from Empleado where Id_em=9
select * from Inventario where Tipo_de_pieza='Maderas'
select Id_pz,Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Producto,Empresa,Valor_Proveedor from Inventario where Descripcion like'%{}%'
"select Id_pz,Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Producto,Empresa,Valor_Proveedor from Inventario where Tipo_de_pieza Like'%{0}%'"
select * from Empleado where No_Documento_em = 2
select No_Documento_em from Empleado (select No_Documento_Em From Empleado where No_Documento=2)

select Fecha_Realizacion_Pc,Empresa,Id_Pc from Pedido_Compra where Id_Pc Like'%{0}%'
select No_Documento_em from Empleado where No_Documento_em

select Inventario Id_pz,Maquinaria Id_ma from Inventario inner join Maquinaria on Inventario Id_pz = Maquinaria Id_pz

select a.Id_pz, b.Tipo_Ma, b.Garantia
from Inventario a, Maquinaria b
where 
select Fecha_Realizacion_Pc,Empresa,Id_Pc from Pedido_Compra
select  Id_Pc, Fecha_Realizacion_Pc, Empresa from Pedido_Compra
Select * from Pedido_Compra
Select * from Proveedor
Select * from Inventario
Insert into Pedido_Compra (Cantidad_Comprada_Pc,Fecha_Realizacion_Pc,Fecha_Entrega_Pc,Valor_Total_Prov,Valor_Total_Pc,Subtotal_Pc,Iva_Pc,Empresa,Id_pz) values(1,'sad','asd',1,2,3,4,'Hola',2)
Insert into Pedido_Compra  values(1,'sad','asd',1,2,3,4,'Hola',1)
Insert into Proveedor values ('Hola',1,2,'xd                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    