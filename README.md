# MULTI CLICK-SKILL BUTTON BIEL LIÑÁN

### Long press threshold = 500 miliseconds
### Double press threshold = 250 miliseconds
### Se utiliza la tecla espacio, no click.

- El update chequea cuando el espacio está siendo presionado y cuando no
- Cuando se presiona entra en la funcion del propio input, aqui ocurre todo el loop del sistema

- Para el long press utiliza un task delay para comprobar cuando se completa la condicion de longPresstask, si se cumple la llama
- Para el double press utilizo un timer, si el tiempo entre la primera y segunda presion es menor a el threshold, llama al debug de la segunda
- Para el short press un else

### Cuando haces el double press debuga la opcion C pero despues de esta también la A, no he conseguido solucionar este error :(

