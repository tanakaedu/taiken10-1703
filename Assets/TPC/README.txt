#
# SDユニティちゃんのアニメーションを使った操作アセット Ver0.3
# @copyright 2018 YuTanaka
#
# - 田中が作成したもの
#   - MITライセンス LICENSE.md
# - SDユニティちゃん
#   - UnityChanフォルダーのREADME_SD_UnityChan、および、Licenseフォルダーを参照してください
# - プレイヤーキャラクター
#   - [だいしブログ様. MagicaVoxelで作ったプリキュアをUnityで動かす](https://github.dev7.jp/b/2015/12/15/precureadv20151213/)の素体とアーマチュア
#

unitychan( http://unity-chan.com/ )の公式サイトからダウンロードできる以下のSDユニテ
ィちゃんのアニメーションを利用して、上下左右、ジャンプの移動ができるようにするアセット
です。

- [SDユニティちゃん 3Dモデルデータ](http://unity-chan.com/download/releaseNote.php?id=SDUnityChan)
- [SDこはくちゃんズ・小碓学園夏＆冬制服モデル](http://unity-chan.com/download/releaseNote.php?id=SDKohakuchanz)

# 利用方法
- Scenesフォルダー内のTPCシーンを開くとデモシーンで操作確認ができます。

# 操作方法
- 上下左右キー：移動
- Zキー：ジャンプ
- 左Shiftキー：走る

# ユニティちゃんのプレハブ
- TPC/Prefabs/Playerがユニティちゃんのアニメで操作できるプレイヤーです
- 表情や瞬き、LookAtは外しています

# モデルの差し替え
MagicaVoxelで作成したキャラクターなどに差し替えることを想定しています。

- Playerプレハブの子どものモデルを削除
- 差し替えたいモデルをPlayerの子どもにします

[EOF]
