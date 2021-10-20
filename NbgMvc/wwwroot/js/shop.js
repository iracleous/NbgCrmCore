function showProducts() {
    let EndPoint = 'https://localhost:44369/api/product';
    let Method = 'GET';

    localStorage.setItem("user", "Dimitris");
    localStorage.setItem("userId",1);

    $.ajax({
        url: EndPoint,
        method: Method
    }).done(response => parse(response))
        .fail(() => manageFailure())  ;
}

function parse(response) {
    $('#resultArea').html('<h1> List of products </h1><br />')

    let products = response['$values']
    $('#resultArea').append("<table  >");
    products.forEach(product =>
        $('#resultArea').append(
            "<tr><td><a href='#' onclick='showProduct(" + product['productId'] + ")'>"
                + product['name'] + '<a></td><td>' + product['price'] + '</td></tr>')
    );
    $('#resultArea').append('</table>')
}

function failure() {
    $('#resultArea').html('Failure in communication')
}

function showProduct(productId) {
    let EndPoint = 'https://localhost:44369/api/product/' + productId;
    let Method = 'GET';

    $.ajax({
        url: EndPoint,
        method: Method
    }).done(product => {

        $('#resultArea').html(product['productId'] + '<br />')
        $('#resultArea').append(product['name']
            + '<br />'
            + product['price']
            + '<br />'
            + "<img src='" + product['imageFilename'] + "' width='100px' height='100px'/><br />"
            + "<button onclick='buy(" + product['productId'] + ")'>Buy It</button>" );
    })
        .fail(() => manageFailure())  ;
}

function buy(productId) {

    let userId = localStorage.getItem("userId");

    let UrlToCreateBasket = 'https://localhost:44369/api/basket/user/' + userId;
    let Method= "Post";
    $.ajax({
        url: UrlToCreateBasket,
        method: Method
    }).done(basketId => localStorage.setItem("basketId", basketId))
        .fail(failMessage => console.log("fail in basket creation"));

    let UrlAddToBasket = 'https://localhost:44369/api/basket/' + basketId + '/product/' + productId;
 
    $.ajax({
        url: UrlAddToBasket,
        method: Method
    }).done(result => $('#resultArea').html('The product has been added to basket'));
 
    console.log("userId"+userId)
     
}


function showBasket() {

    let userId = localStorage.getItem("userId");
    let basketId = localStorage.getItem("basketId");

    console.log("userId " + userId)
    console.log("basketId " + basketId)


    let UrlGetBasketWithProduct = 'https://localhost:44369/api/basket/' + basketId;
    let Method = "GET";

    $.ajax({
        url: UrlGetBasketWithProduct,
        method: Method
    }).done(result => $('#resultArea').html(JSON.stringify(result)))     ;
}