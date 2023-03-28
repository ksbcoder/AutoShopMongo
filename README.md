# AutoShopMongo

Implementing connection to MongoDB from Auto Shop project

## Contracts

### GET 
```
[
  {
    "shop_id": "string",
    "name_shop": "string",
    "address_shop": "string",
    "phone_shop": "string",
    "state_shop": true
  }
]
```

### POST 
```
{
  "name_shop": "string",
  "address_shop": "string",
  "phone_shop": "string",
  "state_shop": true
}
```

### PUT 
```
{
  "shop_id": "string",
  "name_shop": "string",
  "address_shop": "string",
  "phone_shop": "string",
  "state_shop": true
}
```

### DELETE 
```
shop_id
```
