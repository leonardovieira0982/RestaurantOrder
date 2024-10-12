#README

This project is a proof of concept to meet the requirement of development testing. To run this project, you need to have docker desktop installed on the machine. After that, run the RabbitMQ image installation.


To run a RabbitMQ container

docker run -d --hostname restaurant-order --name rabbit-server -e RABBITMQ_DEFAULT_USER=guest -e RABBITMQ_DEFAULT_PASS=guest -p 5672:5672 -p 15672:15672 rabbitmq:3-management

