# public-repository
repositoryをpublic状態にしてActionなどの動作を確認するためのRepository

■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
### `develop2 branch`
master：未マージ分があるためCodeScanでERRORとなる。

develop：tetorisで大量のerrorが残っているためCodeScanでERRORとなる。

develop2：test00（hello world）とtest01（sanmokunarabe）は

local buildでもCodeScanning でも ERRORがない状態となっている。

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
