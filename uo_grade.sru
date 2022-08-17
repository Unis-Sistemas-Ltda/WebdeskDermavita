$PBExportHeader$uo_grade.sru
forward
global type uo_grade from nonvisualobject
end type
end forward

global type uo_grade from nonvisualobject
end type
global uo_grade uo_grade

type variables
integer ii_qtd_colunas = 70
integer ii_qtd_tamanhos

long il_cor_fundo
constant long il_cor_fundo_branco = 16777215
constant long il_cor_fundo_button_face = 67108864

integer ii_borda_qtd
constant integer ii_borda_qtd_no_border = 0
constant integer ii_borda_qtd_lowered = 5

string is_ultima_coluna
boolean ib_mostrar_total = false
end variables

forward prototypes
public function boolean of_carrega_grade (string as_item, ref datawindow adw_grade)
public subroutine of_propriedade_dw (ref datawindow adw_grade)
public function boolean of_codigo_barras (string as_codigo_barras, ref string as_referencia, ref string as_item)
public function boolean of_item_com_grade (string as_cod_item)
public function long of_qtd_cor_item (string as_item)
public function boolean of_carrega_grade_engenharia (string as_item, ref datawindow adw_grade, ref datawindow adw_cab, long al_qtd_cores, long al_seq_cor_inicial)
public function boolean of_carrega_grade_engenharia_filtro (string as_item, ref datawindow adw_grade, ref datawindow adw_cab, string as_filtro)
public function boolean of_codigo_barras (string as_codigo_barras, ref string as_referencia, ref string as_item, integer ai_tipo)
end prototypes

public function boolean of_carrega_grade (string as_item, ref datawindow adw_grade);u_ds lds_tamanhos
u_ds lds_cores
long ll
long ll_t
long ll_linha
string ls_desc
string ls_cor
string ls_coluna
string ls_tamanho
string ls_descricao
string ls_venda_fracionada
boolean lb_numero = true

lds_tamanhos = create u_ds
lds_tamanhos.of_constructor('dw_grade_tamanhos')

lds_cores = create u_ds
lds_cores.of_constructor('dw_grade_cores')

//Verifica se o item existe
select descricao, isnull(venda_fracionada,'N')
  into :ls_descricao, :ls_venda_fracionada
  from item
 where cod_item = :as_item;

if isnull(ls_venda_fracionada) then ls_venda_fracionada = 'N'

if sqlca.sqlcode = 100 then return false

lds_tamanhos.retrieve(as_item)

ii_qtd_tamanhos = lds_tamanhos.rowcount()

lds_cores.retrieve(as_item)
for ll = 1 to lds_cores.rowcount()
	ll_linha = adw_grade.insertrow(0)
	ls_cor   = lds_cores.object.cod_cor[ll]
	ls_desc  = lds_cores.object.descricao[ll]
	adw_grade.object.cor[ll_linha]           = ls_cor
	adw_grade.object.descricao_cor[ll_linha] = ls_desc
		
	for ll_t = 1 to lds_tamanhos.rowcount()
		ls_tamanho = lds_tamanhos.object.cod_tamanho[ll_t]
		ls_coluna = 'tamanho_' + string(ll_t)
		adw_grade.setitem(ll, ls_coluna, ls_tamanho)
		
		ls_coluna = 'qtd_' + string(ll_T)
		adw_grade.Modify(ls_coluna + ".Visible='1'")
		
		is_ultima_coluna = 'qtd_' + string(ll_t)		

		if ls_venda_fracionada = 'S' then
			adw_grade.Modify(ls_coluna + ".EditMask.Mask='###,###.##'")
		end if

	next
	
next

if lds_tamanhos.rowcount() < ii_qtd_colunas and lds_tamanhos.rowcount() > 0 then
	for ll = lds_tamanhos.rowcount() + 1 to ii_qtd_colunas
		ls_coluna = 'qtd_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")
		
		ls_coluna = 'compute_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")		
		
	next
end if


return true
end function

public subroutine of_propriedade_dw (ref datawindow adw_grade);//Chamar essa função antes de carregar a datawindow, pois senão o fundo ficará preto
long ll
string ls_coluna

//Cor de fundo
if not isnull(il_cor_fundo) and il_cor_fundo <> 0 then
	adw_grade.Modify("DataWindow.Color='" + string(il_cor_fundo) + "'")
end if

//Borda dos campos da quantidade
if not isnull(ii_borda_qtd) then
	
	for ll = 1 to ii_qtd_colunas
		ls_coluna = 'qtd_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Border='" + string(ii_borda_qtd) + "'")		
	next	
	
end if

end subroutine

public function boolean of_codigo_barras (string as_codigo_barras, ref string as_referencia, ref string as_item);return of_codigo_barras(as_codigo_barras, as_referencia, as_item, 1)
end function

public function boolean of_item_com_grade (string as_cod_item);string ls_com_grade

setnull(ls_com_grade)

select isnull(com_grade,'N')
  into :ls_com_grade
  from item
 where cod_Item = :as_cod_item;
 
if isnull(ls_com_grade) then
	ls_com_grade = 'N'
end if

if ls_com_grade = 'S' then
	return true
else
	return false
end if
end function

public function long of_qtd_cor_item (string as_item);long ll_qtd

select count(1)
  into :ll_qtd
  from item_cor
 where cod_item = :as_item;
 
 return ll_qtd
end function

public function boolean of_carrega_grade_engenharia (string as_item, ref datawindow adw_grade, ref datawindow adw_cab, long al_qtd_cores, long al_seq_cor_inicial);u_ds lds_tamanhos
u_ds lds_cores
long ll
long ll_t
long ll_linha
string ls_desc
string ls_cor
string ls_coluna
string ls_tamanho
string ls_descricao
boolean lb_numero = true

lds_tamanhos = create u_ds
lds_tamanhos.of_constructor('dw_grade_tamanhos')

lds_cores = create u_ds
lds_cores.of_constructor('dw_grade_cores')

//Verifica se o item existe
select descricao
  into :ls_descricao
  from item
 where cod_item = :as_item;

if sqlca.sqlcode = 100 then return false

adw_grade.reset()
adw_cab.reset()
lds_tamanhos.retrieve(as_item)

ii_qtd_tamanhos = lds_tamanhos.rowcount()

lds_cores.retrieve(as_item)

for ll = al_seq_cor_inicial to al_qtd_cores
	if ll <= lds_cores.rowcount() then
		ll_linha = adw_grade.insertrow(0)
		if adw_cab.rowcount() = 0 then
			adw_cab.insertrow(0)
		end if
		ls_cor   = lds_cores.object.cod_cor[ll]
		ls_desc  = lds_cores.object.descricao[ll]
		adw_grade.object.cor[ll_linha]       = ls_cor
		adw_grade.object.descricao_cor[ll_linha] = ls_desc
		
		for ll_t = 1 to lds_tamanhos.rowcount()
			ls_tamanho = lds_tamanhos.object.cod_tamanho[ll_t]
			ls_coluna = 'tamanho_' + string(ll_t)
			adw_grade.setitem(ll, ls_coluna, ls_tamanho)
			adw_cab.setitem(1, ls_coluna, ls_tamanho)
			
			ls_coluna = 'tamanho_componente_' + string(ll_t)
			adw_grade.Modify(ls_coluna + ".Visible='1'")
			adw_cab.Modify(ls_coluna + ".Visible='1'")
			
			ls_coluna = 'qtd_' + string(ll_T)
			adw_grade.Modify(ls_coluna + ".Visible='1'")
			
			is_ultima_coluna = 'qtd_' + string(ll_t)	
			
		next
	end if
next

if lds_tamanhos.rowcount() < ii_qtd_colunas and lds_tamanhos.rowcount() > 0 then
	for ll = lds_tamanhos.rowcount() + 1 to ii_qtd_colunas
		ls_coluna = 'qtd_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")
		
		ls_coluna = 'tamanho_componente_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")
		adw_cab.Modify(ls_coluna + ".Visible='0'")
		
		ls_coluna = 'compute_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")		
	next
end if

return true
end function

public function boolean of_carrega_grade_engenharia_filtro (string as_item, ref datawindow adw_grade, ref datawindow adw_cab, string as_filtro);u_ds lds_tamanhos
u_ds lds_cores
long ll
long ll_t
long ll_linha
string ls_desc
string ls_cor
string ls_coluna
string ls_tamanho
string ls_descricao
boolean lb_numero = true

lds_tamanhos = create u_ds
lds_tamanhos.of_constructor('dw_grade_tamanhos')

lds_cores = create u_ds
lds_cores.of_constructor('dw_grade_cores')

//Verifica se o item existe
select descricao
  into :ls_descricao
  from item
 where cod_item = :as_item;

if sqlca.sqlcode = 100 then return false

adw_grade.reset()
adw_cab.reset()

lds_tamanhos.retrieve(as_item)

ii_qtd_tamanhos = lds_tamanhos.rowcount()

if isnull(as_filtro) then as_filtro = ''
as_filtro = trim(as_filtro)

if as_filtro <> '' then
	lds_cores.setfilter('')
	lds_cores.filter()
	lds_cores.setfilter(as_filtro)
	lds_cores.filter()
	lds_cores.sort()
else
	lds_cores.setfilter('')
	lds_cores.filter()
	lds_cores.sort()
end if

lds_cores.retrieve(as_item)
for ll = 1 to lds_cores.rowcount()
		ll_linha = adw_grade.insertrow(0)
		if adw_cab.rowcount() = 0 then
			adw_cab.insertrow(0)
		end if
		ls_cor   = lds_cores.object.cod_cor[ll]
		ls_desc  = lds_cores.object.descricao[ll]
		adw_grade.object.cor[ll_linha]       = ls_cor
		adw_grade.object.descricao_cor[ll_linha] = ls_desc
		
		for ll_t = 1 to lds_tamanhos.rowcount()
			ls_tamanho = lds_tamanhos.object.cod_tamanho[ll_t]
			ls_coluna = 'tamanho_' + string(ll_t)
			adw_grade.setitem(ll, ls_coluna, ls_tamanho)
			adw_cab.setitem(1, ls_coluna, ls_tamanho)
			
			ls_coluna = 'tamanho_componente_' + string(ll_t)
			adw_grade.Modify(ls_coluna + ".Visible='1'")
			adw_cab.Modify(ls_coluna + ".Visible='1'")
			
			ls_coluna = 'qtd_' + string(ll_T)
			adw_grade.Modify(ls_coluna + ".Visible='1'")
			
			is_ultima_coluna = 'qtd_' + string(ll_t)	
			
		next
next

if lds_tamanhos.rowcount() < ii_qtd_colunas and lds_tamanhos.rowcount() > 0 then
	for ll = lds_tamanhos.rowcount() + 1 to ii_qtd_colunas
		ls_coluna = 'qtd_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")
		
		ls_coluna = 'tamanho_componente_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")
		adw_cab.Modify(ls_coluna + ".Visible='0'")
		
		ls_coluna = 'compute_' + string(ll)
		adw_grade.Modify(ls_coluna + ".Visible='0'")		
	next
end if

return true
end function

public function boolean of_codigo_barras (string as_codigo_barras, ref string as_referencia, ref string as_item, integer ai_tipo);//ai_tipo -> 1-Produto 2-Caixa
boolean lb_dun14

if len(as_codigo_barras) = 14 then
	lb_dun14 = true
else 
	lb_dun14 = false
end if

if ai_tipo = 1  then
	select first cod_referencia, cod_item
	  into :as_referencia, :as_item
	  from item_referencia
	 where left(codigo_barras,12) = left(:as_codigo_barras,12);
else
	select first cod_referencia, cod_item
	  into :as_referencia, :as_item
	  from item_referencia
	 where left(codigo_barras_caixa,12) = left(:as_codigo_barras,12);
end if

//Se não achou na referencia, vai buscar no item
if sqlca.sqlcode = 100 then
	
	if lb_dun14 then
		select first cod_item
		  into :as_item
		  from item_codigo_barra
		 where cod_barra = substring(:as_codigo_barras,2,12)
			and ( (:ai_tipo = 1 and isnull(tipo,'C') = 'P') or (:ai_tipo = 2 and isnull(tipo,'C') = 'C') );
	else
		select first cod_item
		  into :as_item
		  from item_codigo_barra
		 where cod_barra = :as_codigo_barras
			and ( (:ai_tipo = 1 and isnull(tipo,'C') = 'P') or (:ai_tipo = 2 and isnull(tipo,'C') = 'C') );
	end if
	
	
	if sqlca.sqlcode = 100 then
		return false
	end if
end if

if isnull(as_item) then as_item = ''
if isnull(as_referencia) then as_referencia = ''

return true

end function

on uo_grade.create
call super::create
TriggerEvent( this, "constructor" )
end on

on uo_grade.destroy
TriggerEvent( this, "destructor" )
call super::destroy
end on

