

// 从1.txt加载题目
async function loadQuestions() {
    try {
        const response = await fetch('questions.txt');
        if (!response.ok) {
            throw new Error('无法加载题目文件');
        }
        const text = await response.text();
        return parseQuestions(text);
    } catch (error) {
        console.error('加载题目失败:', error);
        // 如果加载失败，使用默认题目
        return getDefaultQuestions();
    }
}

// 解析1.txt文件内容并随机选取10道题
function parseQuestions(text) {
    const lines = text.split('\n').filter(line => line.trim() !== '');
    const allQuestions = [];
    
    // 解析所有题目
    for (const line of lines) {
        const match = line.match(/^\d+\.([^A]+)A\.([^B]+)B\.([^C]+)C\.([^D]+)D\.([^（]+)（([A-D])）/);
        if (match) {
            allQuestions.push({
                question: match[1].trim(),
                options: [
                    match[2].trim(),
                    match[3].trim(),
                    match[4].trim(),
                    match[5].trim()
                ],
                answer: match[6].trim()
            });
        }
    }
    
    // 随机选取10道题
    return getRandomQuestions(allQuestions, 10);
}

// 从所有题目中随机选取指定数量的题目
function getRandomQuestions(allQuestions, count) {
    // 如果题目数量不足，返回全部题目
    if (allQuestions.length <= count) {
        return allQuestions;
    }
    
    // 复制数组以避免修改原数组
    const shuffled = [...allQuestions];
    // Fisher-Yates洗牌算法
    for (let i = shuffled.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [shuffled[i], shuffled[j]] = [shuffled[j], shuffled[i]];
    }
    
    // 返回前count道题目
    return shuffled.slice(0, count);
}


// 默认题目（如果无法加载文件时使用）
function getDefaultQuestions() {
    return [
        {
            question: "城市生活垃圾从哪里来？",
            options: ["人类活动", "垃圾桶", "街上", "超市"],
            answer: "A"
        },
        {
            question: "我国城市人均日产垃圾量是多少？",
            options: ["0.7 - 0.8公斤", "2公斤", "1.5公斤", "1.0 - 1.2公斤"],
            answer: "A"
        },
        // 更多默认题目...
    ];
}

// 游戏状态
let questions = [];
let currentQuestionIndex = 0;
let score = 0;
let selectedOption = null;
let quizCompleted = false;

// DOM元素
const questionElement = document.getElementById('question');
const optionsElement = document.getElementById('options');
const feedbackElement = document.getElementById('feedback');
const nextButton = document.getElementById('next-btn');
const scoreElement = document.getElementById('score');
const progressElement = document.getElementById('progress');
const startScreen = document.getElementById('start-screen');
const quizWrapper = document.getElementById('quiz-wrapper');
const startButton = document.getElementById('start-btn');

// 修改initQuiz函数
async function initQuiz() {
    // 显示开始界面，隐藏答题界面
    startScreen.style.display = 'block';
    quizWrapper.style.display = 'none';
    
    // 加载题目但不立即显示
    questions = await loadQuestions();
    currentQuestionIndex = 0;
    score = 0;
    quizCompleted = false;
    showQuestion();
    updateScore();
    updateProgress();

    // 设置开始按钮事件
    startButton.addEventListener('click', startQuiz);
}

// 初始化测验
// 新增开始答题函数
function startQuiz() {
    // 隐藏开始界面，显示答题界面
    startScreen.style.display = 'none';
    quizWrapper.style.display = 'block';
    
    // 重置游戏状态
    currentQuestionIndex = 0;
    score = 0;
    quizCompleted = false;
    
    // 开始第一题
    showQuestion();
    updateScore();
    updateProgress();
}

// 显示当前问题
function showQuestion() {
    const currentQuestion = questions[currentQuestionIndex];
    questionElement.textContent = currentQuestion.question;
    
    // 清空选项容器
    optionsElement.innerHTML = '';
    
    // 重置状态
    selectedOption = null;
    feedbackElement.className = 'feedback';
    
    // 创建选项按钮
    currentQuestion.options.forEach((option, index) => {
        const optionButton = document.createElement('div');
        optionButton.className = 'option';
        optionButton.textContent = `${String.fromCharCode(65 + index)}. ${option}`;
        optionButton.dataset.option = String.fromCharCode(65 + index);
        
        optionButton.addEventListener('click', () => selectOption(optionButton));
        
        optionsElement.appendChild(optionButton);
    });
    
    // 更新下一题按钮文本
    nextButton.textContent = currentQuestionIndex === questions.length - 1 ? '查看结果' : '下一题';
}

// 选择选项
function selectOption(optionElement) {
    if (selectedOption !== null) return;
    
    // 移除之前的选择
    const options = document.querySelectorAll('.option');
    options.forEach(opt => opt.classList.remove('selected'));
    
    // 标记当前选择
    optionElement.classList.add('selected');
    selectedOption = optionElement.dataset.option;
    
    // 检查答案
    const currentQuestion = questions[currentQuestionIndex];
    const isCorrect = selectedOption === currentQuestion.answer;
    
    if (isCorrect) {
        score++;
        optionElement.classList.add('correct');
        feedbackElement.textContent = '回答正确！';
        feedbackElement.className = 'feedback correct';
    } else {
        // 标记错误选项和正确选项
        optionElement.classList.add('wrong');
        options.forEach(opt => {
            if (opt.dataset.option === currentQuestion.answer) {
                opt.classList.add('correct');
            }
        });
        feedbackElement.textContent = `回答错误！正确答案是 ${currentQuestion.answer}`;
        feedbackElement.className = 'feedback wrong';
    }
    
    updateScore();
}

// 更新分数显示
function updateScore() {
    scoreElement.textContent = `得分: ${score}/${currentQuestionIndex + 1}`;
}

// 更新进度条
function updateProgress() {
    const progress = ((currentQuestionIndex + 1) / questions.length) * 100;
    progressElement.style.width = `${progress}%`;
}

// 下一题或显示结果
function nextQuestion() {
    if (selectedOption === null && !quizCompleted) {
        alert('请选择一个答案！');
        return;
    }
    
    if (currentQuestionIndex < questions.length - 1 && !quizCompleted) {
        currentQuestionIndex++;
        showQuestion();
        updateProgress();
    } else {
        showResult();
    }
}
function showResult() {
    quizCompleted = true;
    questionElement.textContent = `测验完成！你的最终得分是 ${score}/${questions.length}`;
    optionsElement.innerHTML = '';
    feedbackElement.className = 'feedback';
    feedbackElement.textContent = '';
    
    // 修改按钮为"再来一次"
    nextButton.textContent = '再来一次';
    nextButton.removeEventListener('click', nextQuestion);
    nextButton.addEventListener('click', () => {
        // 返回开始界面
        startScreen.style.display = 'block';
        quizWrapper.style.display = 'none';
    });}
// 显示最终结果
// function showResult() {
//     quizCompleted = true;
//     questionElement.textContent = `测验完成！你的最终得分是 ${score}/${questions.length}`;
//     optionsElement.innerHTML = '';
//     feedbackElement.className = 'feedback';
//     feedbackElement.textContent = '';
    
//     // 添加重新开始按钮
//     nextButton.textContent = '重新开始';
//     nextButton.removeEventListener('click', nextQuestion);
//     nextButton.addEventListener('click', initQuiz);
// }

// 事件监听
nextButton.addEventListener('click', nextQuestion);

// 开始测验
document.addEventListener('DOMContentLoaded', initQuiz);