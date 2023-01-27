## actualizaciones:

- Creacion de un modulo de prueba para el envio de datos estaticos hacia Sap
- Pruebas en el modulo del frontend para el recibo de datos.
- insercion de datos exitosa en sap b1
- Cambio en la cadena de conexion a SAP.


## Problemas y/o excepciones:

- falla el modulo al enviar json a webmethod
- manda status 200 pero webmethod no recibe el objeto 


# Excepcion(Error: RPC_E_SERVERFAULT)

El Problema se dio cuando quieres conectarte a un programa el cual no se encuentra en el equipo, en este caso usando SAP B1, y DIAPI para llenar datos de manera automaica.

- Desactivar el firewall (en mi caso, tanto para usarlo en escritorio como en web)
- el sistema al que se quiere conectar no esta instalado en el equipo



