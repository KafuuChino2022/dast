function jumpTo(pageName) {
    // ȡ��ǰĿ¼�ľ���·����Ȼ�����ҳ����
    let base = location.href.substring(0, location.href.lastIndexOf('/') + 1);
    location.href = base + pageName + ".html";
    postMsg(location.href);
}