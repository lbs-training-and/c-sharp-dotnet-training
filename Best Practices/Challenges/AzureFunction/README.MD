# BurgetBytes Azure Function

## Contents
- [Endpoints](#endpoints)
   * [List Products](#list-products)
      + [Response Format](#response-format)
      + [Response Example](#response-example)
   * [List Orders](#list-orders)
      + [Response Format](#response-format-1)
      + [Response Example ](#response-example-1)
   * [Create Order](#create-order)
      + [Request Format](#request-format)
      + [Request Example](#request-example)
      + [Response Format](#response-format-2)
      + [Response Example](#response-example-2)

## Endpoints

### List Products

**URL**: `/products`
**Method**: GET

#### Response Format
```json
[
    {
        "id": int,
        "name": string,
        "description": string,
        "price": decimal
    },
    ...
]
```

#### Response Example
```json
[
    {
        "id": 1,
        "name": "ByteBurger",
        "description": "Delicious beef burger",
        "price": 5.99
    },
    {
        "id": 2,
        "name": "BitFries",
        "description": "Bits of fries",
        "price": 1.99
    },
    {
        "id": 3,
        "name": "HashBrown",
        "description": "A small hashbrown",
        "price": 0.99
    },
    {
        "id": 4,
        "name": "ClassCola",
        "description": "A cold glass of cola",
        "price": 1.5
    },
    {
        "id": 5,
        "name": "StackShake",
        "description": "A giant milkshake",
        "price": 3.5
    }
]
```

### List Orders

**URL**: `/orders/{id:int?}`
**Method**: GET

#### Response Format

```json
{
    "deliveryAddress": string,
    "billingAddress": string,
    "email": string,
    "phone": string,
    "orderProducts": [
        {
            "quantity": int,
            "notes": string,
            "product": {
                "id": int,
                "name": string,
                "description": string,
                "price": decimal
            }
        },
        ...
    ]
}
```

#### Response Example 
```json
{
    "deliveryAddress": "123 Dock St",
    "billingAddress": "456 Leeds Rd",
    "email": "customer@example.com",
    "phone": "1234567890",
    "orderProducts": [
        {
            "quantity": 2,
            "notes": "No cheese",
            "product": {
                "id": 1,
                "name": "ByteBurger",
                "description": "Delicious beef burger",
                "price": 5.99
            }
        },
        {
            "quantity": 1,
            "notes": "",
            "product": {
                "id": 5,
                "name": "StackShake",
                "description": "A giant milkshake",
                "price": 3.5
            }
        }
    ]
}
```

### Create Order

**URL**: `/orders`
**Method**: POST

#### Request Format
```json
{
    "deliveryAddress": string,
    "billingAddress": string,
    "email": string,
    "phone": string,
    "orderProducts": [
        {
            "quantity": int,
            "notes": string,
            "product": {
                "id": int
            }
        }
    ]
}
```

#### Request Example
```json
{
    "deliveryAddress": "123 Dock St",
    "billingAddress": "456 Leeds Rd",
    "email": "customer@example.com",
    "phone": "1234567890",
    "orderProducts": [
        {
            "quantity": 2,
            "notes": "No cheese",
            "product": {
                "id": 1,
                "name": "ByteBurger",
                "description": "Delicious beef burger",
                "price": 5.99
            }
        },
        {
            "quantity": 1,
            "notes": "",
            "product": {
                "id": 5,
                "name": "StackShake",
                "description": "A giant milkshake",
                "price": 3.5
            }
        }
    ]
}
```

#### Response Format
```json
{
    "OrderId": int
}
```

#### Response Example
```json
{
    "OrderId": 123
}
```