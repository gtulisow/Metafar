# Uso de la API

## Endpoint Login

Este endpoint permite autenticar a un usuario proporcionando el número de tarjeta y el PIN asociados. Si el número de tarjeta y el PIN son válidos y coinciden entre sí, el sistema generará y devolverá un token JWT que debe ser utilizado para acceder a los otros endpoints de la API. Es importante tener en cuenta que si se ingresan cuatro PIN incorrectos, la tarjeta quedará bloqueada y no se permitirá el acceso.

### Ejemplo de Uso:

```http
POST /api/Security/login
Content-Type: application/json

{
  "cardNumber": "1111222233334444",
  "pin": "5678"
}
```


## Endpoint Saldo

La api debe de contar con un endpoint el cual dado un nro de tarjeta retorne la siguiente informacion: nombre del usuario, numero de cuenta, saldo actual y fecha de la última extracción

### Ejemplo de Uso:

```http
GET /api/UserAccount/Balance/1111222233334444
Authorization: Bearer <token JWT>
```


## Endpoint Retiro

Permite realizar una extracción de fondos asociada a un número de tarjeta y un monto específico. Retorna un resumen de la operación realizada si todo es correcto. En caso de saldo insuficiente, devuelve un código de error.

### Ejemplo de Uso:

```http
POST /api/Withdrawal
Content-Type: application/json
Authorization: Bearer <token JWT>

{
  "cardNumber": "1111222233334444",
  "amount": 2
}

```

## Endpoint Operaciones

Retorna el historial de operaciones realizadas asociadas a un número de tarjeta, paginadas en conjuntos de 10 registros.

### Ejemplo de Uso:

```http
GET /api/Operation/Paginated?cardNumber=1111222233334444&pageNumber=1
Authorization: Bearer <token JWT>
```


### Recuerda que en cada solicitud a estos endpoints, debes incluir el encabezado Authorization con el token JWT obtenido al autenticarte en el endpoint Login.

