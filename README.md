# public-repository
repositoryをpublic状態にしてActionなどの動作を確認するためのRepository

■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
### `develop branch`
C#絡みのERRORが大量発生しており、developへのpush時CodeScanning

（CodeQL）エラーによりpullrequestを発行してもERRORを理由にマージは

できない状態。

このエラーを全て解消しなければDevelopへのマージはできない。

上記helloworldと三目並べは正常に.exeは作成された状態となっている。

■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

`CodeScanning格納 BuildはAutoBuildを利用`

◆GitHubAction CodeScan（.Github/workflow）

https://github.com/operation-check/testrep/tree/master/.github/workflows

`VisualStudio管理用ファイルが入っているフォルダ`

◆VisualStudio用フォルダ（.vs）

https://github.com/operation-check/testrep/tree/master/.vs

------------------------------------------

`Code 以下２つのフォルダ内にプログラムコードと実行ファイルを格納済。`

`hello worldを表示するだけのもの。`

・test00：HelloWorld(test00)

https://github.com/operation-check/testrep/tree/master/test00

------------------------------------------

`コンソールにて三目並べができる「らしい」が起動は一応非推奨。
あくまでも「コードのサンプル」としてだけのもの。`

・test01：三目並べ(sanmokunarabe)

https://github.com/operation-check/testrep/tree/master/sanmokunarabe

------------------------------------------

`動けばテトリスが遊べる「らしい」が現状はエラー多数で動作不能。
また起動は一応非推奨。
CodeScanもERRORとなっていることが確認できる`

・test02：テトリス(tetris)

https://github.com/operation-check/public-repository/tree/develop/tetris
