// 显示敬请期待弹窗
function showComingSoon() {
    const modal = document.getElementById('comingSoonModal');
    modal.style.display = 'flex';
    
    // 点击弹窗外部关闭
    modal.addEventListener('click', function(e) {
        if(e.target === modal) {
            modal.style.display = 'none';
        }
    });
}

// 游戏跳转函数
function startGame() {
    window.location.href = '564.html';
}

// DOM加载完成后执行
document.addEventListener('DOMContentLoaded', function() {
    // 绑定更多功能按钮事件
    const moreBtn = document.querySelector('.more-game-btn');
    if(moreBtn) {
        moreBtn.addEventListener('click', showComingSoon);
    }
    
    // 绑定弹窗关闭按钮
    const closeBtn = document.querySelector('.modal-close');
    if(closeBtn) {
        closeBtn.addEventListener('click', function() {
            document.getElementById('comingSoonModal').style.display = 'none';
        });
    }
});