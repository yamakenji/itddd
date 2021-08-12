# Chapter 11 アプリケーションを1から組み立てる

## 11.1 アプリケーションを組み立てるフロー

1. 求められる機能を確認する
2. ユースケースを洗い出す
3. 必要となる概念、存在するルールからアプリケーションに必要な知識を選び出す
4. ドメインオブジェクトを準備する
5. ドメインオブジェクトを用いてユースケースを実現するアプリケーションサービスを実装する

## 11.2 題材とする機能

SNSのサークル機能を実現する

### 11.2.1 サークル機能の分析

``` plantuml

actor "ユーザ" as User

usecase "サークルを作成する" as CreateCircle
usecase "サークルに参加する" as JoinCircle

User --> CreateCircle
User --> JoinCircle

```

サークルの前提条件

* サークル名は3文字以上20文字以下
* サークル名は全てのサークルで重複しない
* サークルに所属するユーザの最大数はサークルのオーナーとなるユーザを含めて30名まで

## 11.3 サークルの知識やルールをオブジェクトとして準備する

ドメインオブジェクトを準備する

``` plantuml

@startuml

class CircleId << ValueObject >> {
  +Value : string
}
class CircleName << ValueObject >> {
  +Value : string
  +Equals() : boolean
}
note bottom of CircleName
  サークル名は3文字以上20文字以下
  サークル名は全てのサークルで重複しない
end note

class Circle << Entity >> {
  +Id : CircleId
  +Name : CircleName
  +Owner : User
  +Members : List<User>
}
class User
Circle ..> CircleId
Circle ..> CircleName
Circle ..> User

interface ICircleRepository <<Repository>> {
  +Save() : void
  +Find() : CircleId
  +Find() : CircleName
}
interface ICircleFactory{
  +Create() : Circle
}
class CircleService{
  -circleRepository : ICircleRepository
  +Exists() : boolean
}
CircleService ..> ICircleRepository
@enduml

```

## 11.4 ユースケースを組み立てる

