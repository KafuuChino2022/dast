function jumpTo(pageName) {
    // 取当前目录的绝对路径，然后加上页面名
    let base = location.href.substring(0, location.href.lastIndexOf('/') + 1);
    location.href = base + pageName + ".html";
    postMsg(location.href);
}