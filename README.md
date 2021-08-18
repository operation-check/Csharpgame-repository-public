# public-repository
repositoryをpublic状態にしてActionなどの動作を確認するためのRepository

◆GitHubAction CodeScan（.Github/workflow）

https://github.com/operation-check/testrep/tree/master/.github/workflows

◆VisualStudio用フォルダ（.vs）

https://github.com/operation-check/testrep/tree/master/.vs

--Code

・test00：HelloWorld(test00)

https://github.com/operation-check/testrep/tree/master/test00


・test01：三目並べ(sanmokunarabe)

https://github.com/operation-check/testrep/tree/master/sanmokunarabe


・test02：テトリス(tetris)

https://github.com/operation-check/public-repository/tree/develop/tetris

C#絡みのERRORが大量発生しており、developへのpush時CodeScan（CodeQL）によりpullrequestの発行自体を止められている。

これを解除しなければDevelopへのmergeはできず、上記「helloworld/三目並べ」のみ正常に.exeは作成された状態となっている。
